using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Packet
{
    [Serializable]
    public class DataItemsQueryDTO : Object
    {
        public int Id { get; set; }
        public int DeviceId { get; set; }
        public string Name { get; set; }
        public bool CanListen { get; set; }
        public int ParentDeviceId { get; set; }
        public string Offset { get; set; }
        public int ItemTypeId { get; set; }
        public string TypeName { get; set; }
        public string DeviceName { get; set; }
        public string AbsoleteItemName { get; set; }
        public string CurrentValue { get; set; }
        public string LastUpdateTime { get; set; }

        public DataItemsQueryDTO()
        {
        }

        public DataItemsQueryDTO(int Id, int DeviceId, string name, bool CanListen, int ParentDeviceId, string Offset, int ItemTypeId, string TypeName, string DeviceName, string AbsoluteItemName, string CurentValue, string LastUpdateTime)
        {
            this.Id = Id;
            this.DeviceId = DeviceId;
            this.Name = Name;
            this.CanListen = CanListen;
            this.ParentDeviceId = ParentDeviceId;
            this.Offset = Offset;
            this.ItemTypeId = ItemTypeId;
            this.TypeName = TypeName;
            this.DeviceName = DeviceName;
            this.AbsoleteItemName = AbsoleteItemName;
            this.CurrentValue = CurrentValue;
            this.LastUpdateTime = LastUpdateTime;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Id", this.Id);
            info.AddValue("DeviceId", this.DeviceId);
            info.AddValue("Name", this.Name);
            info.AddValue("CanListen", this.CanListen);
            info.AddValue("ParentDeviceId", this.ParentDeviceId);
            info.AddValue("Offset", this.Offset);
            info.AddValue("ItemTypeId", this.ItemTypeId);
            info.AddValue("TypeName", this.TypeName);
            info.AddValue("DeviceName", this.DeviceName);
            info.AddValue("AbsoleteItemName", this.AbsoleteItemName);
            info.AddValue("CurrentValue", this.CurrentValue);
            info.AddValue("LastUpdateTime", this.LastUpdateTime);
        }

        public DataItemsQueryDTO(SerializationInfo info, StreamingContext context)
        {
            this.Id = (int)info.GetValue("CurrentWeight", typeof(int));
            this.DeviceId = (int)info.GetValue("OldWeight", typeof(int));
            this.Name = (string)info.GetValue("OldWeight", typeof(string));
            this.CanListen = (bool)info.GetValue("CellNumber", typeof(bool));
            this.ParentDeviceId = (int)info.GetValue("PLCSetOpen", typeof(int));
            this.Offset = (string)info.GetValue("PLCSetClose", typeof(string));
            this.ItemTypeId = (int)info.GetValue("CurrentWeight", typeof(int));
            this.TypeName = (string)info.GetValue("PLCDropoffWind", typeof(string));
            this.DeviceName = (string)info.GetValue("Error", typeof(string));
            this.AbsoleteItemName = (string)info.GetValue("ErrorList", typeof(string));
            this.CurrentValue = (string)info.GetValue("Reset", typeof(string));
            this.LastUpdateTime = (string)info.GetValue("Reset", typeof(string));
        }



    }
}
