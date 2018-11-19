using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Docking2010.Views.Tabbed;
using TVM_WMS.SERVER.Interfaces;
using TVM_WMS.SERVER.Infrastructure.Logger;
using TVM_WMS.SERVER.Infrastructure;
using WatsonTcp;
using Packet;
using System.IO;
using System.Diagnostics;
using S7.Net;
using Ninject;
using System.Runtime.Serialization.Formatters.Binary;
using System.Timers;

namespace TVM_WMS.SERVER
{
    public partial class MainTabFm : DevExpress.XtraEditors.XtraForm
    {
        private const int WM_SYSCOMMAND = 0x0112;
        private const int SC_MINIMIZE = 0xF020;
        public int intervalCycler = 0;
        public int switchCounter = 0;
        private WatsonTcpServer server = null;
        private ISettingsService settingsService;
        public List<Client> clients;
        public List<PLC> plc;

        public MainTabFm()
        {
            InitializeComponent();
            trayIcon.Visible = false;
            trayIcon.Icon = this.Icon;
            documentManager.MdiParent = this;
            documentManager.View = tabbedView;
            tabbedView.DocumentGroupProperties.ShowTabHeader = false;

            this.ReloadSettings();
            

        }

        public bool ReloadSettings()
        {
            settingsService = Program.kernel.Get<ISettingsService>();
            int typeDbId = settingsService.GetDeviceTypes().FirstOrDefault(wt => wt.TypeName == "DB").Id;
            int currentCountUsePlcExample = settingsService.GetDevices(ConfigClass.Instance.LocalCPUID).Count(dt => dt.TypeId == typeDbId);

            clients = new List<Client>(currentCountUsePlcExample);
            plc = new List<PLC>(currentCountUsePlcExample);

            for (int i = 0; i < currentCountUsePlcExample; i++)
            {
                clients.Add(new Client());
                plc.Add(new PLC());
            }


                logMessageEdit.MaskBox.AppendText(DateTime.Now + " " + currentCountUsePlcExample + " " + Environment.NewLine);
            
            return true;
        }

        void testFm_sendDataFromFormEvent(object sender, UserEventArgs e)
        {
            switch (e.sendingInformation.typeCommand)
            {
                case Utils.TypeCommand.Control:
                    switch (e.sendingInformation.controlCommand)
	                {
                        case Utils.ControlCommand.Start:
                            this.RunServerRun(ConfigClass.Instance.GlobalLocalSettings.GeneralServerIp, Convert.ToInt16(ConfigClass.Instance.GlobalLocalSettings.GeneralServerPort));
                            break;

		                case Utils.ControlCommand.Stop:

                            this.StopServerStop();
                            break;

                        case Utils.ControlCommand.Reload:

                            this.ReloadSettings();
                            break;  

                        default:
                            break;
	                }
                        break;

                case Utils.TypeCommand.Inform:
                    logMessageEdit.MaskBox.AppendText(DateTime.Now + ": " + e.sendingInformation.message + Environment.NewLine);
                    break;

                default:
                    break;
            }

        }


        private void menuNavBar_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            switch (e.Link.Item.Name)
            {
                case "testsItem":
                    TestFm testFm = new TestFm();
                    testFm.sendDataFromFormEvent += new EventHandler<UserEventArgs>(testFm_sendDataFromFormEvent);
                    testFm.Text = "Тестирование";
                    testFm.MdiParent = this;
                    testFm.Show();
                    break;

                case "settItem":
                    SettingsFm settingsFm = new SettingsFm();
                    settingsFm.sendDataFromFormEvent += new EventHandler<UserEventArgs>(testFm_sendDataFromFormEvent);
                    settingsFm.Text = "Настройки";
                    settingsFm.MdiParent = this;
                    settingsFm.Show();
                    break;


                default:
                    break;
            }
        }

        #region Server's              

        public bool RunServerRun(string ipServer, int portServer)
        {
            try
            {
                splashScreenManager.ShowWaitForm();
                server = new WatsonTcpServer(ipServer, portServer, ClientConnected, ClientDisconnected, MessageReceived, true);
                logMessageEdit.MaskBox.AppendText(DateTime.Now + " Сервер успешно запущен." + Environment.NewLine);
                serverLiveOrDieTimer.Start();
                splashScreenManager.CloseWaitForm();
                MessageBox.Show("Сервер успешно запущен.\n", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return true;

            }
            catch (Exception ex)
            {
                logMessageEdit.MaskBox.AppendText(DateTime.Now + " Ошибка запуска сервера ( "+ ex +" )." + Environment.NewLine);
                MessageBox.Show("Ошибка запуска сервера.\n" + ex.Message , "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
        }

        public bool StopServerStop()
        {
            if (ConfigClass.Instance.server != null)
            {
                ConfigClass.Instance.server = null;
                logMessageEdit.MaskBox.AppendText(DateTime.Now + " Сервер успешно остановлен." + Environment.NewLine);
                MessageBox.Show("Сервер успешно остановлен.\n", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                logMessageEdit.MaskBox.AppendText(DateTime.Now + " Сервер не удалось остановить." + Environment.NewLine);
                MessageBox.Show("Сервер не удалось остановить.\n", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }


        public delegate void WriteItemDelegate(string varAlias, object varValue, int index);

        public void WriteItem(string varAlias, object varValue, int index)
        {
            plc[index].WriteTag(varAlias, varValue);
        }


        public delegate void AddMessageLogDelegate(string message, string ipPort);

        public void AddMessageLog(string message, string ipPort)
        {
            logMessageEdit.MaskBox.AppendText(message);
        }

        public bool ClientConnected(string ipPort)
        {
            Invoke(new AddMessageLogDelegate(AddMessageLog), new object[] { DateTime.Now + " Клиент подключился: " + ipPort + " порт.", ipPort });
            //MessageBox.Show("Клиент с нами . "+ ipPort+"\n", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);'''
            return true;
        }

        public bool ClientDisconnected(string ipPort)
        {
            Invoke(new AddMessageLogDelegate(AddMessageLog), new object[] { DateTime.Now + " Клиент отключился: " + ipPort + " порт.", ipPort });
            //logMessageEdit.MaskBox.AppendText(DateTime.Now + " Клиент отключился: " + ipPort + " порт." + Environment.NewLine);
            return true;
        }

        public bool MessageReceived(string ipPort, byte[] data)
        {
            Object receivedObject = new Object();

            if (data != null && data.Length > 0)
            {
                receivedObject = ByteArrayToObject(data);
                //logMessageEdit.MaskBox.AppendText(DateTime.Now + " Client: " + ipPort + ", command: " + ((PacketDTO)receivedObject).typeCommand + Environment.NewLine);


                switch (((PacketDTO)receivedObject).typeCommand)
                {
                    case Utils.TypeCommand.Control:
                        
                        switch (((PacketDTO)receivedObject).controlCommand)
	                    {
                            case Utils.ControlCommand.Connected:
                                clients.FirstOrDefault(cl => cl.ClientPort == null).ClientPort = ipPort;
                                clients.First(cl=>cl.ClientPort == ipPort).ClientStatus = Utils.StatusClient.Connect;
                                int jindex = clients.FindIndex(fi => fi.ClientPort == ipPort);

                                clients[jindex].ClientDBId = ((PacketDTO)receivedObject).idDb;
                                clients[jindex].ClientPLCId = ((PacketDTO)receivedObject).idPlc;
                                clients[jindex].ClientDBName = ((PacketDTO)receivedObject).nameDb;
                                clients[jindex].ClientPLCName = ((PacketDTO)receivedObject).namePlc;
                                plc[jindex] = new PLC();

                                var plcSource = (ConfigClass.PlcSettingSource)ConfigClass.Instance.PlcSettingList.FirstOrDefault(s => s.DeviceId == clients[jindex].ClientPLCId);
                                var cpu = plcSource.CpuType;

                                plc[jindex].Connect(cpu, plcSource.Ip, plcSource.Rack, plcSource.Slot);

                                //plc[index].WriteTag((ConfigClass.Instance.GlobalLocalSettings.WatchDogDBName + "." + ConfigClass.Instance.GlobalLocalSettings.WatchDogPCOffset).ToString(), true);

                                plc[jindex].WriteTag("DB30.DBX0.0", true);

                                plc[jindex].CurrentDb = Int32.Parse(ConfigClass.Instance.DeviceSettingsList.First(s => s.DeviceId == clients[jindex].ClientDBId && s.KindName == "DataBlockIndex").SettingValue);
                                plc[jindex].Interval = Convert.ToDouble((int)TimeSpan.FromSeconds(1000).TotalMilliseconds);
                                clients[jindex].ClientTaglist = ConfigClass.Instance.DataItemList.Where(s => s.DeviceId == clients[jindex].ClientDBId).ToList();
                                
                                plc[jindex].TimerStart(clients[jindex].ClientTaglist);

                                clients[jindex].WatchDogTimer = new System.Timers.Timer();
                                clients[jindex].WatchDogTimer.Interval = 1000;
                                clients[jindex].WatchDogTimer.SynchronizingObject = null;
                                clients[jindex].WatchDogTimer.Elapsed += (sender, e) => watchDogEvent(sender, e, jindex);
                                clients[jindex].WatchDogTimer.Start();




            //clients[index].ClientTaglist = new List<DataItems>();
                                


                                //clients[jindex].SyncrinizedTimer = new System.Timers.Timer();
                                //clients[jindex].SyncrinizedTimer.Interval = 200;
                                //clients[jindex].SyncrinizedTimer.SynchronizingObject = null;
                                //clients[jindex].SyncrinizedTimer.Elapsed += (sender, e) => timerSendTaglistEvent(sender, e, jindex);
                                //clients[jindex].SyncrinizedTimer.Start();
                                //clients.Add(new Client(ipPort, null, null, Utils.StatusClient.Connect, null, null));

                                Invoke(new AddMessageLogDelegate(AddMessageLog), new object[] { DateTime.Now + " Клиент: " + ipPort + ", подключился к серверу."  + Environment.NewLine, ipPort });

                                break;

                            case Utils.ControlCommand.Disconnected:
                                int dindex = clients.FindIndex(fi => fi.ClientPort == ipPort);
                                clients[dindex].ClientStatus = Utils.StatusClient.Disconnect;
                                clients[dindex].ClientPort = null;
                                if (clients[dindex].TaglistSenderTimer != null)
                                    clients[dindex].TaglistSenderTimer.Stop();
                                //clients[dindex].SyncrinizedTimer.Stop();
                                plc[dindex].TimerStop();
                                //plc[dindex].WriteTag((ConfigClass.Instance.GlobalLocalSettings.WatchDogDBName + "." + ConfigClass.Instance.GlobalLocalSettings.WatchDogPCOffset).ToString(), false);
                                plc[dindex].WriteTag("DB30.DBX0.0", false);
                                //clients.First(cl => cl.ClientPort == ipPort).ClientStatus = Utils.StatusClient.Disconnect;
                                //clients.First(cl => cl.ClientPort == ipPort).ClientPort = null;
                                //clients.First(cl => cl.ClientPort == ipPort).TaglistSenderTimer.Stop();
                                //clients.First(cl => cl.ClientPort == ipPort).SyncrinizedTimer.Stop();

                                Invoke(new AddMessageLogDelegate(AddMessageLog), new object[] { DateTime.Now + " Клиент: " + ipPort + ", отключился от сервера." + Environment.NewLine, ipPort });

                                //logMessageEdit.MaskBox.AppendText(DateTime.Now + " Клиент: " + ipPort + ", отключился от контроллера контроллеру." + Environment.NewLine);
                                break;                   

                            case Utils.ControlCommand.Read:

                                int index = clients.FindIndex(fi => fi.ClientPort == ipPort);

                                clients[index].TaglistSenderTimer = new System.Timers.Timer();
                                clients[index].TaglistSenderTimer.Interval = 1000;
                                clients[index].TaglistSenderTimer.SynchronizingObject = null;
                                clients[index].TaglistSenderTimer.Elapsed += (sender, e) => timerSendTaglistEvent(sender, e, index);
                                clients[index].TaglistSenderTimer.Start();
                                

                                
                                break;

		                    default:
                                break;
	                    }

                        break;

                    case Utils.TypeCommand.Inform:

                       // Invoke(new AddMessageLogDelegate(AddMessageLog), new object[] { DateTime.Now + " Клиент: " + ipPort + ", команда: " + ((PacketDTO)receivedObject).typeCommand + Environment.NewLine, ipPort });
                        Invoke(new AddMessageLogDelegate(AddMessageLog), new object[] { DateTime.Now + " " + ((PacketDTO)receivedObject).message + " " + Environment.NewLine, ipPort });
                        break;

                    default:
                        break;
                }



            }







            //logMessageEdit.MaskBox.AppendText(DateTime.Now + " Message from: " + ipPort + ", " + ((PacketDTO)receivedObject).message + Environment.NewLine);
            return true;
        }

        public void timerSendTaglistEvent(object sender, ElapsedEventArgs e, int index)
        {
            clients[index].ClientTaglist = plc[index].Return();
            PacketDTO currentPacket = new PacketDTO(Utils.TypeCommand.Control, Utils.ControlCommand.Write, clients[index].ClientPLCId,clients[index].ClientPLCName, clients[index].ClientDBId, clients[index].ClientDBName, "", ObjectToByteArray((Object)clients[index].ClientTaglist));
            var peremen = clients[index].ClientTaglist.SingleOrDefault(pl => pl.Name == "WatchDogPLC").CurrentValue;


            server.Send(clients[index].ClientPort, ObjectToByteArray((Object)currentPacket));
        }




        public void watchDogEvent(object sender, ElapsedEventArgs e, int index)
        {
            clients[index].ClientTaglist = plc[index].Return();

            
            //string peremen = clients[index].ClientTaglist.SingleOrDefault(pl => pl.Name == "WatchDogPLC").CurrentValue;
            try
            {
                if (bool.Parse(clients[index].ClientTaglist.SingleOrDefault(pl => pl.Name == "WatchDogPLC").CurrentValue))
                {
                    //plc[index].WriteTag(clients[index].ClientDBName + ".DBX276.7", true);

                    //this.Invoke(new MethodInvoker(delegate
                    //{
                    //    plc[index].WriteTag("DB1.DBX276.7", true);
                    //}));

                    Invoke(new WriteItemDelegate(WriteItem), new object[] {"DB1.DBX276.7", true, index });


                    //++intervalCycler;

                    //++switchCounter;

                    Invoke(new AddMessageLogDelegate(AddMessageLog), new object[] { DateTime.Now + "True" + Environment.NewLine, null });

                    // logMessageEdit.MaskBox.AppendText(DateTime.Now + "true " + Environment.NewLine);
                }
                else
                {
                    //plc[index].WriteTag(clients[index].ClientDBName + ".DBX276.7", false);

                    //this.Invoke(new MethodInvoker(delegate
                    //{
                    //    plc[index].WriteTag("DB1.DBX276.7", false);
                    //}));

                    //--intervalCycler;

                    //++switchCounter;

                    Invoke(new AddMessageLogDelegate(AddMessageLog), new object[] { DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss:fff") + "False" + Environment.NewLine, null });

                    //logMessageEdit.MaskBox.AppendText(DateTime.Now + "False " + Environment.NewLine);
                }


                if (switchCounter > 15)
                {
                    switchCounter = 0;
                    intervalCycler = 0;
                }

            }
            catch (Exception ex)
            {
                //logMessageEdit.MaskBox.AppendText(DateTime.Now + " Ошибка: "+ ex + Environment.NewLine);
                Invoke(new AddMessageLogDelegate(AddMessageLog), new object[] { DateTime.Now + " Ошибка: " + ex + Environment.NewLine, null });
            }
            finally
            {
                //plc[index].RefreshTags();
            }
            
            
            
            
            
            
            //clients[index].ClientTaglist = plc[index].Return();
            //PacketDTO currentPacket = new PacketDTO(Utils.TypeCommand.Control, Utils.ControlCommand.Write, clients[index].ClientPLCId, clients[index].ClientPLCName, clients[index].ClientDBId, clients[index].ClientDBName, "", ObjectToByteArray((Object)clients[index].ClientTaglist));
            //server.Send(clients[index].ClientPort, ObjectToByteArray((Object)currentPacket));
        }



        public void timerSyncronizedEvent(object sender, ElapsedEventArgs e, int index)
        {
            //if (clients[index].ClientStatus == Utils.StatusClient.Connect)
            //{
            //    PacketDTO currentPacket = new PacketDTO(Utils.TypeCommand.Control, Utils.ControlCommand.Control, clients[index].ClientPLCId, clients[index].ClientDBId, "", null);
            //    server.Send(clients[index].ClientPort, ObjectToByteArray((Object)currentPacket));
            //}

        }

        #endregion

        public byte[] ObjectToByteArray(Object obj)
        {
            if (obj == null)
                return null;

            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, obj);

            return ms.ToArray();
        }



        public Object ByteArrayToObject(byte[] arrBytes)
        {
            MemoryStream memStream = new MemoryStream();
            BinaryFormatter binForm = new BinaryFormatter();
            memStream.Write(arrBytes, 0, arrBytes.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            Object obj = (Object)binForm.Deserialize(memStream);

            return obj;
        }

      

        public byte[] ReadMultipleBytes(Plc plc, int numBytes, int db, int startByteAdr = 0)
        {
            List<byte> resultBytes = new List<byte>();
            int index = startByteAdr;
            while (numBytes > 0)
            {
                var maxToRead = (int)Math.Min(numBytes, 200);
                byte[] bytes = plc.ReadBytes(DataType.DataBlock, db, index, (int)maxToRead);
                if (bytes == null)
                    return new List<byte>().ToArray<byte>();
                resultBytes.AddRange(bytes);
                numBytes -= maxToRead;
                index += maxToRead;
            }
            return resultBytes.ToArray<byte>();
        }


        #region Event's               

        protected override void OnClosing(CancelEventArgs e)
        {          
            this.ShowInTaskbar = false;
            trayIcon.Visible = false;
            Process.GetCurrentProcess().Kill();
        }

        private void serverLiveOrDieTimer_Tick(object sender, EventArgs e)
        {
            if (ConfigClass.Instance.server != null)
                this.Icon = new Icon(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + @"\Images\run.ico");
            else
                this.Icon = new Icon(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + @"\Images\stop.ico");

            trayIcon.Icon = this.Icon;
        }

        private void trayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            trayIcon.Visible = false;
            this.ShowInTaskbar = true;
            WindowState = FormWindowState.Normal;
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_SYSCOMMAND)
            {
                if (m.WParam.ToInt32() == SC_MINIMIZE)
                {
                    this.WindowState = FormWindowState.Minimized;
                    this.ShowInTaskbar = false;
                    trayIcon.Visible = true;
                    return;
                }
            }
            base.WndProc(ref m);
        }

        #endregion

        private void MainTabFm_FormClosed(object sender, FormClosedEventArgs e)
        {
            clients.First(cl => cl.ClientPort == null).ClientStatus = Utils.StatusClient.Connect;

            if (clients != null)
            {
                int index = clients.FindIndex(fi => fi.ClientStatus == Utils.StatusClient.Connect);
                plc[index].WriteTag("DB30.DBX0.0", false);
            }
        }

        
    }
}