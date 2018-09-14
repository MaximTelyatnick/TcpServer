using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Packet
{
    [Serializable]
    public class TagDTO : Object
    {
        public double CurrentWeight { get; set; }
        public double OldWeight { get; set; }
        public short CellNumber { get; set; }
        public short PLCLoadStatus { get; set; }
        public short PLCSetOpen { get; set; }
        public short PLCSetClose { get; set; }
        public short PLCDropoffWind { get; set; }
        public bool Error { get; set; }
        public string ErrorList { get; set; }
        public bool Reset { get; set; }
        // Метод, вызываемый при сериализации
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("CurrentWeight", this.CurrentWeight);
            info.AddValue("OldWeight", this.OldWeight);
            info.AddValue("CellNumber", this.CellNumber);
            info.AddValue("PLCLoadStatus", this.PLCLoadStatus);
            info.AddValue("PLCSetOpen", this.PLCSetOpen);
            info.AddValue("PLCSetClose", this.PLCSetClose);
            info.AddValue("PLCDropoffWind", this.PLCDropoffWind);
            info.AddValue("Error", this.Error);
            info.AddValue("ErrorList", this.ErrorList);
            info.AddValue("Reset", this.Reset);
        }
        public TagDTO()
        {

        }
        // Конструктор, вызываемый при десериализации
        public TagDTO(SerializationInfo info, StreamingContext context)
        {
            this.CurrentWeight = (double)info.GetValue("CurrentWeight", typeof(double));
            this.OldWeight = (double)info.GetValue("OldWeight", typeof(double));
            this.CellNumber = (short)info.GetValue("OldWeight", typeof(short));
            this.PLCLoadStatus = (short)info.GetValue("CellNumber", typeof(short));
            this.PLCSetOpen = (short)info.GetValue("PLCSetOpen", typeof(short));
            this.PLCSetClose = (short)info.GetValue("PLCSetClose", typeof(short));
            this.CurrentWeight = (short)info.GetValue("CurrentWeight", typeof(short));
            this.PLCDropoffWind = (short)info.GetValue("PLCDropoffWind", typeof(short));
            this.Error = (bool)info.GetValue("Error", typeof(bool));
            this.ErrorList = (string)info.GetValue("ErrorList", typeof(string));
            this.Reset = (bool)info.GetValue("Reset", typeof(bool));
        }
    }
}
