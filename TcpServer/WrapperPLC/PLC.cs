using S7.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpServer
{
    public class PLC
    {
        private List<DataItemsQueryDTO> PlcListenVarList { get; set; }

        public TimeSpan CycleReadTime { get; private set; }
        public int CurrentDb { get; set; }
        public double Interval { get; set; }

        public ConnectionStates ConnectionState { get { return plcDriver != null ? plcDriver.ConnectionState : ConnectionStates.Offline; } }

        private ISyncPlcDriver plcDriver;

        System.Timers.Timer timer = new System.Timers.Timer();

        public DateTime lastReadTime;

        public PLC()
        {

        }

        public PLC(List<DataItemsQueryDTO> TagList)
        {


            PlcListenVarList = TagList;

            timer.Interval = 1000;//Interval; // ms
            timer.Elapsed += timer_Elapsed;
            timer.Enabled = true;
            lastReadTime = DateTime.Now;

        }

        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (plcDriver == null || plcDriver.ConnectionState != ConnectionStates.Online)
            {
                return;
            }

            timer.Enabled = false;
            CycleReadTime = DateTime.Now - lastReadTime;
            try
            {
                RefreshTags();
            }
            finally
            {
                timer.Enabled = true;
                lastReadTime = DateTime.Now;
            }
        }

        public void TimerStart(List<DataItemsQueryDTO> TagList)
        {
            PlcListenVarList = TagList;

            timer.Interval = Interval; // ms
            timer.Elapsed += timer_Elapsed;
            timer.Enabled = true;
            lastReadTime = DateTime.Now;

            RefreshTags();

            timer.Start();

            // Logger.Logger.Log.Debug("Запустили таймер PLC, текущая БД №" + CurrentDb);
        }

        public void TimerStop()
        {
            timer.Stop();

            // Logger.Logger.Log.Debug("Остановили таймер PLC, текущая БД №" + CurrentDb);
        }

        public void Connect(CpuType cpu, string ipAddress, short rack, short slot)
        {
            plcDriver = new S7NetPlcDriver(cpu, ipAddress, rack, slot);
            plcDriver.Connect();
        }

        public void Disconnect()
        {
            if (plcDriver == null || this.ConnectionState == ConnectionStates.Offline)
            {
                return;
            }

            plcDriver.Disconnect();
        }

        private void RefreshTags()
        {
            if (PlcListenVarList != null)
            {
                for (int i = 0; i < PlcListenVarList.Count; i++)
                {
                    var value = plcDriver.ReadVar(PlcListenVarList[i].AbsoleteItemName);
                    int offset = Int32.Parse(PlcListenVarList[i].Offset.Substring(0, PlcListenVarList[i].Offset.IndexOf('.')));

                    switch (PlcListenVarList[i].TypeName)
                    {
                        case "Real":
                            PlcListenVarList[i].CurrentValue = (value != null) ? Math.Round(((uint)value).ConvertToDouble(), 2).ToString() : "<Данные не получены>";
                            break;
                        case "UInt":
                            PlcListenVarList[i].CurrentValue = (value != null) ? ((ushort)value).ConvertToShort().ToString() : "<Данные не получены>";
                            break;
                        case "Bool":
                            PlcListenVarList[i].CurrentValue = (value != null) ? ((bool)value).ToString() : "<Данные не получены>";
                            break;
                        case "String":
                            PlcListenVarList[i].CurrentValue = S7.Net.Types.String.FromByteArray(plcDriver.ReadMultipleBytes(254, CurrentDb, offset + 2)); ;
                            break;
                        default:
                            break;
                    }

                    PlcListenVarList[i].LastUpdateTime = DateTime.Now.ToLongTimeString();
                }
            }
        }

        public List<DataItemsQueryDTO> GetTags()
        {
            if (PlcListenVarList != null)
            {
                for (int i = 0; i < PlcListenVarList.Count; i++)
                {
                    var value = plcDriver.ReadVar(PlcListenVarList[i].AbsoleteItemName);
                    int offset = Int32.Parse(PlcListenVarList[i].Offset.Substring(0, PlcListenVarList[i].Offset.IndexOf('.')));

                    switch (PlcListenVarList[i].TypeName)
                    {
                        case "Real":
                            PlcListenVarList[i].CurrentValue = (value != null) ? Math.Round(((uint)value).ConvertToDouble(), 2).ToString() : "<Данные не получены>";
                            break;
                        case "UInt":
                            PlcListenVarList[i].CurrentValue = (value != null) ? ((ushort)value).ConvertToShort().ToString() : "<Данные не получены>";
                            break;
                        case "Bool":
                            PlcListenVarList[i].CurrentValue = (value != null) ? ((bool)value).ToString() : "<Данные не получены>";
                            break;
                        case "String":
                            PlcListenVarList[i].CurrentValue = S7.Net.Types.String.FromByteArray(plcDriver.ReadMultipleBytes(254, CurrentDb, offset + 2)); ;
                            break;
                        default:
                            break;
                    }

                    PlcListenVarList[i].LastUpdateTime = DateTime.Now.ToLongTimeString();
                }
            }
            return PlcListenVarList;
        }

        public void ResetAllVar()
        {
            for (int i = 0; i < PlcListenVarList.Count; i++)
            {
                switch (PlcListenVarList[i].TypeName)
                {
                    case "Real":
                    case "UInt":
                        plcDriver.WriteItem(PlcListenVarList[i].AbsoleteItemName, 0);
                        break;
                    case "Bool":
                        plcDriver.WriteItem(PlcListenVarList[i].AbsoleteItemName, false);
                        break;
                    case "String":
                        plcDriver.WriteEmptyTextItem(PlcListenVarList[i], CurrentDb, 127);
                        break;
                    default:
                        break;
                }
            }
        }

        public void WriteTag(string varAlias, object varValue)
        {
            plcDriver.WriteItem(varAlias, varValue);
        }

        public void WriteEmptyTextTag(DataItemsQueryDTO tag, int replicate)
        {
            plcDriver.WriteEmptyTextItem(tag, CurrentDb, replicate);
        }

        public List<DataItemsQueryDTO> Return()
        {
            return PlcListenVarList;
        }
    }
}
