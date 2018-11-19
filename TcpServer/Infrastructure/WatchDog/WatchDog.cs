using S7.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace TVM_WMS.SERVER.Infrastructure.WatchDog
{
    public class WatchDog
    {
        public string nameCurrentDb;
        public double timerInterval;
        //public string ipAddress;
        //public short rack;
        //public short slot;
        public ISyncPlcDriver plcDriver;
        public System.Timers.Timer timer;
        //public CpuType cpu;
        //public sbyte intervalCycler;
        public sbyte switchCounter;
        public bool switchFlag;

        public List<DataItemsWatchDog> dataItemsWatchDogList { get; set; }

        private ConnectionStates connectionState {
            get { return plcDriver != null ? plcDriver.ConnectionState : ConnectionStates.Offline; }
        }

        

        public WatchDog()
        {
        }

        public WatchDog(CpuType cpu, string ipAddress, short rack, short slot, double interval, string nameCurrentDb)        
        {
            this.cpu = cpu;
            this.ipAddress = ipAddress;
            this.rack = rack;
            this.slot = slot;
            this.timerInterval = interval;
            this.nameCurrentDb = nameCurrentDb;

        }

        public void Connect()
        {
            //Logger.Logger.InitLogger();
            if (cpu == null || rack == null || slot == null || ipAddress == null)
            {
                MessageBox.Show("Не выполнено подключение к контроллеру! Проверте параметры.", "Тест соединения", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                plcDriver = new S7NetPlcDriver(cpu, ipAddress, rack, slot);
                plcDriver.Connect();

                switchFlag = false;
                intervalCycler = 0;
                switchCounter = 0;

                //Logger.Logger.Log.Debug("Запуск WatchDog");

                dataItemsWatchDogList = Initalize();


                timer = new System.Timers.Timer();

                TimerStart();
            }
            catch (Exception ex)
            {
                //Logger.Logger.Log.Debug("Ошибка запуска WatchDog");

                TimerStop();

            }

        }

        public void Disconnect()
        {
            if (plcDriver == null || this.connectionState == ConnectionStates.Offline)
            {
                return;
            }

            TimerStop();

            plcDriver.Disconnect();

            plcDriver = null;

        }

        public void TimerStart()
        {

            timer.Interval = this.timerInterval;
            timer.Elapsed += timer_Elapsed;
            timer.Enabled = true;

            RefreshTags();

            timer.Start();

            //Logger.Logger.Log.Debug("Запустили таймер WatchDog, текущая БД №" + currentDb);
        }

        public void TimerStop()
        {

            timer.Stop();

            //Logger.Logger.Log.Debug("Остановили таймер WatchDog, текущая БД №" + currentDb);
        }


        public List<DataItemsWatchDog> Initalize()
        {
            List<DataItemsWatchDog> watchDogList = new List<DataItemsWatchDog>();
            watchDogList.AddRange(new List<DataItemsWatchDog>
                {
                    new DataItemsWatchDog()
                    {
                        Name = "WatchDogPLC",
                        AbsoleteItemName = (this.nameCurrentDb + ".DBX276.6"),
                        CurrentValue = "",
                        LastUpdateTime = "",
                        Offset = ("DBX276.6")
                    },
                    new DataItemsWatchDog()
                    {
                        Name = "WatchDogPC",
                        AbsoleteItemName = (this.nameCurrentDb + ".DBX276.7"),
                        CurrentValue = "",
                        LastUpdateTime = "",
                        Offset = ("DBX276.7") 
                    },
                });

            return watchDogList;
        }

        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (plcDriver == null || plcDriver.ConnectionState != ConnectionStates.Online)
            {
                //MessageBox.Show("Соиденение разорвано c PLC(таймер WatchDog)!", "Тест соединения", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Logger.Logger.Log.Debug("Соиденение разорвано c PLC(таймер WatchDog)!" + currentDb);
                return;
            }

            timer.Enabled = false;

            try
            {

                if (Convert.ToBoolean(dataItemsWatchDogList[0].CurrentValue))
                {
                    //WriteTag(dataItemsWatchDogList[1].AbsoleteItemName, true);

                    WriteTag("DB27.DBX276.7", true);

                    //Logger.Logger.Log.Debug("Получили true, записали true " + intervalCycler + " " + DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss:fff"));

                    ++intervalCycler;

                    ++switchCounter;

                }
                else
                {
                    //WriteTag(dataItemsWatchDogList[1].AbsoleteItemName, false);

                    WriteTag("DB27.DBX276.7", false);

                    //Logger.Logger.Log.Debug("Получили false, записали false " + intervalCycler + " " + DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss:fff"));

                    --intervalCycler;

                    ++switchCounter;

                }

                if (switchCounter > 15)
                {
                    switchCounter = 0;
                    intervalCycler = 0;
                }
            }
            finally
            {
                RefreshTags();

                if (intervalCycler > 5 || intervalCycler < -5)
                {
                    timer.Enabled = false;
                    MessageBox.Show("Соиденение разорвано c PLC(таймер WatchDog)! Причина: не ответа контроллера.", "Тест соединения", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Logger.Logger.Log.Debug("Connection state " + connectionState + " " + DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss:fff"));
                    //Logger.Logger.Log.Debug("Соиденение разорвано c PLC(таймер WatchDog)! Причина: не ответа контроллера.");
                    plcDriver.DisconnectVegetablePLC();
                }
                else
                {
                    //Logger.Logger.Log.Debug("Connection state " + connectionState + " " + DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss:fff"));

                    timer.Enabled = true;
                    switchFlag = !switchFlag;
                }
            }
        }

        public void WriteTag(string varAlias, object varValue)
        {
            plcDriver.WriteItem(varAlias, varValue);
        }

        private void RefreshTags()
        {
            if (dataItemsWatchDogList != null && plcDriver != null)
            {
                for (int i = 0; i < dataItemsWatchDogList.Count; i++)
                {
                    var value = plcDriver.ReadVar(dataItemsWatchDogList[i].AbsoleteItemName);
                    dataItemsWatchDogList[i].CurrentValue = (value != null) ? ((bool)value).ToString() : "<Данные не получены>";
                    dataItemsWatchDogList[i].LastUpdateTime = DateTime.Now.ToLongTimeString();

                }
            }
        }

    }
}
