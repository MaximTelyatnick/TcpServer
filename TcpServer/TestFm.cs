using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using DevExpress.XtraEditors;
using TVM_WMS.SERVER.Interfaces;
using TVM_WMS.SERVER.Infrastructure.Logger;
using TVM_WMS.SERVER.Infrastructure;
using Ninject;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using TVM_WMS.SERVER.Infrastructure.FormConnect;
using Packet;
using System.Timers;
using System.Windows.Forms;
using System.Threading;
using TVM_WMS.SERVER.Infrastructure.WatchDog;

namespace TVM_WMS.SERVER
{
    public partial class TestFm : DevExpress.XtraEditors.XtraForm
    {

        private ISettingsService settingsService;

        public event EventHandler<UserEventArgs> sendDataFromFormEvent;

        private List<DataItemsQueryDTO> tagList = new List<DataItemsQueryDTO>();

        private BindingSource dataItemBS = new BindingSource();

        private PLC plc;

        public WatchDog watchDog;

        //private ISyncPlcDriver plcWatchDogDriver;

        private System.Timers.Timer eventTimer;

        private System.Timers.Timer watchDogTimer;

        public TestFm()
        {
            InitializeComponent();

            testSplashManager.ShowWaitForm();

            LoadConfiguration();

            testSplashManager.CloseWaitForm();

        }

        private void LoadConfiguration()
        {
         
            CreateDeviceNodes(deviceTree);
            deviceTree.ExpandAll();

        }

        private void CreateDeviceNodes(TreeList tl)
        {
            tl.BeginUnboundLoad();

            int imageIndex = 0;

            settingsService = Program.kernel.Get<ISettingsService>();
            var deviceTypes = settingsService.GetDeviceTypes().Where(dt => (dt.TypeName == "PLC" || dt.TypeName == "DB"));
            var devices = settingsService.GetDevices(ConfigClass.Instance.LocalCPUID);


            foreach (var typeItem in deviceTypes)
            {

                //TreeListNode parentForRootNodes = null;
                //TreeListNode rootNode = tl.AppendNode(new object[] { typeItem.TypeDescription }, parentForRootNodes);

                //rootNode.StateImageIndex = imageIndex;
                //rootNode.Tag = typeItem.Id;


                if (typeItem.TypeName != "DB")
                {
                    var childDeviceList = devices.Where(s => s.TypeId == typeItem.Id);

                    foreach (var deviceItem in childDeviceList)
                    {
                        TreeListNode childNode = tl.AppendNode(new object[] { deviceItem.Name }, 0);
                        childNode.Tag = deviceItem.Id;
                        childNode.StateImageIndex = 1;

                        if (typeItem.TypeName == "PLC")
                        {
                            var childPLCList = ConfigClass.Instance.DataItemList.Where(w => w.ParentDeviceId == deviceItem.Id).Select(s => new { s.DeviceId, s.DeviceName }).Distinct().ToList();

                            if (childPLCList.Count() > 0)
                            {
                                foreach (var dbItem in childPLCList)
                                {
                                    TreeListNode childPLCNode = tl.AppendNode(new object[] { dbItem.DeviceName }, childNode);
                                    childPLCNode.Tag = dbItem.DeviceId;
                                    childPLCNode.StateImageIndex = 3;
                                }
                            }
                        }
                    }
                }
            }
            

            tl.EndUnboundLoad();
        }

        private bool ConnectPlc(int plcDeviceId)
        {
            var plcSource = (ConfigClass.PlcSettingSource)ConfigClass.Instance.PlcSettingList.FirstOrDefault(s => s.DeviceId == plcDeviceId);
            var cpu = plcSource.CpuType;
            

            plc = new PLC();
            plc.Connect(cpu, plcSource.Ip, plcSource.Rack, plcSource.Slot);

            watchDog = new WatchDog(cpu, plcSource.Ip, plcSource.Rack, plcSource.Slot, 1000.0, "");

            if (plc.ConnectionState == ConnectionStates.Online)
            {
                MessageBox.Show("Соиденение успешно!", "Cоединение с контроллером PLC", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return true;
            }
            else
            {
                MessageBox.Show("Ошибка при соединении!", "Cоединение с контроллером PLC", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return false;
            }

        }

        void eventTimer_Tick(object sender, EventArgs e)
        {
            

            try
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    plcVarGridView.BeginDataUpdate();

                    plcVarGrid.DataSource = tagList;

                    plcVarGridView.EndDataUpdate();

                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при записи!\n" + ex.Message, "Запись значения", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
         

            

            

            //plcVarGrid.DataSource = tagList;

            //plcVarGridView.EndDataUpdate();         
           
        }





        public void SendDataForm(FormCommandDTO formCommandDTO)
        {
            if (sendDataFromFormEvent != null)
                sendDataFromFormEvent(this, new UserEventArgs(formCommandDTO));
        }

        private void deviceTree_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            
            if (deviceTree.Nodes.Count > 0)
            {
                switch (deviceTree.FocusedNode.Level)
                {
                    case 0:
                        if(plc != null)
                        {
                            if (plc.CurrentDb == 0)
                            {
                                disconnectPlcBtnItem.Enabled = true;
                                connectPlcBtnItem.Enabled = false;
                                listemStopDbBtnItem.Enabled = false;
                                listenDbBtnItem.Enabled = false;
                            }
                            else
                            {
                                disconnectPlcBtnItem.Enabled = false;
                                connectPlcBtnItem.Enabled = false;
                                listemStopDbBtnItem.Enabled = false;
                                listenDbBtnItem.Enabled = false;
                            }
                        }
                        else
                        {
                            disconnectPlcBtnItem.Enabled = false;
                            connectPlcBtnItem.Enabled = true;
                            listemStopDbBtnItem.Enabled = false;
                            listenDbBtnItem.Enabled = false;
                        }
                        break;

                    case 1:
                        if(plc != null)
                        {
                            if (plc.CurrentDb == 0)
                            {
                                disconnectPlcBtnItem.Enabled = false;
                                connectPlcBtnItem.Enabled = false;
                                listemStopDbBtnItem.Enabled = false;
                                listenDbBtnItem.Enabled = true;
                            }
                            else
                            {
                                disconnectPlcBtnItem.Enabled = false;
                                connectPlcBtnItem.Enabled = false;
                                listemStopDbBtnItem.Enabled = true;
                                listenDbBtnItem.Enabled = false;
                            }
                        }
                        else
                        {
                            disconnectPlcBtnItem.Enabled = false;
                            connectPlcBtnItem.Enabled = false;
                            listemStopDbBtnItem.Enabled = false;
                            listenDbBtnItem.Enabled = false;
                        }

                        break;

                    default:
                        //propertyGrid.DataSource = null;
                        break;
                }
                
            }
        }


        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void connectPlcBtnItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (plc == null)
            {
                try
                {
                    if (ConnectPlc((int)deviceTree.FocusedNode.Tag))
                    {
                        connectPlcBtnItem.Enabled = false;
                        disconnectPlcBtnItem.Enabled = true;
                        deviceTree.FocusedNode.StateImageIndex = 0;

                    }
                    else
                    {
                        connectPlcBtnItem.Enabled = true;
                        disconnectPlcBtnItem.Enabled = false;
                        deviceTree.FocusedNode.StateImageIndex = 1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при подключении: "+ ex.Message, "Cоединение с контроллером PLC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }     
        }

        private void disconnectPlcBtnItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            connectPlcBtnItem.Enabled = true;
            disconnectPlcBtnItem.Enabled = false;
            plc = null;
            deviceTree.FocusedNode.StateImageIndex = 1;
            MessageBox.Show("Отключили контроллер!", "Cоединение с контроллером PLC", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void listenDbBtnItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (plc != null)
            {
                plc.CurrentDb = Convert.ToInt32(deviceTree.FocusedNode.Tag);
                plc.Interval = Convert.ToDouble((int)TimeSpan.FromSeconds(1).TotalMilliseconds);
                tagList = ConfigClass.Instance.DataItemList.Where(s => s.DeviceId == plc.CurrentDb).ToList();

                plc.TimerStart(tagList);

                startTimer();

                watchDog.Connect();

                deviceTree.FocusedNode.StateImageIndex = 2;
                listenDbBtnItem.Enabled = false;
                listemStopDbBtnItem.Enabled = true;
            }
            else
            {
                MessageBox.Show("Контроллер находиться в выключеном состоянии!", "Cоединение с контроллером PLC", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void startTimer()
        {
            if (plc.ConnectionState == ConnectionStates.Online)
            {
                eventTimer = new System.Timers.Timer();
                eventTimer.Interval = 500;
                //eventTimer.SynchronizingObject = null;
                eventTimer.Elapsed += eventTimer_Tick;
                eventTimer.Enabled = true;
                eventTimer.Start();
            }
            else
            {
                MessageBox.Show("Ошибка при соединении!", "Cоединение с контроллером PLC", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
            }
        }

        private void stopTimer()
        {
            //if (plc.ConnectionState == ConnectionStates.Offline)
            //{
            eventTimer.Stop();
            //}
            //else
            //{
            //    MessageBox.Show("Ошибка разрыва соединения!", "Cоединение с контроллером PLC не разорвано ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //    this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            //    this.Close();

            //}
        }

        private void listemStopDbBtnItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (plc != null)
            {
                stopTimer();
                plc.TimerStop();
                plc.CurrentDb = 0;

                deviceTree.FocusedNode.StateImageIndex = 3;
                listemStopDbBtnItem.Enabled = false;
                listenDbBtnItem.Enabled = true;
            }

        }

       
    }
}