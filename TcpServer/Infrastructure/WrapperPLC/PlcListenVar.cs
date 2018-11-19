using System.Collections;
using System;

namespace TVM_WMS.SERVER
{
    public class PlcListenVar
    {
        public double CurrentWeight { get; set; }
        public double OldWeight { get; set; }
        public int CellNumber { get; set; }
        public int PLCLoadStatus { get; set; }
        public int PLCSetOpen { get; set; }
        public int PLCSetClose { get; set; }
        public int PLCDropoffWind { get; set; }
        public bool Error { get; set; }
        public string ErrorList { get; set; }
        public bool MessageReset { get; set; }
        public bool StopBit { get; set; }
        public bool SetOpenAgain { get; set; }
        public bool SetCloseAgain { get; set; }
        public bool GetFromDone { get; set; }
        public bool PutToDone { get; set; }
        public bool WatchDogPLC { get; set; }
        public bool WatchDogPC { get; set; }
    }
    
}
