

namespace TVM_WMS.SERVER.DTO
{
    public class DeviceInfoDTO
    {
        //Devices
        public int DeviceId { get; set; }
        public string Name { get; set; }
        public string LocalCPUID { get; set; }
        //DeviceSettings
        public int? DeviceSettingId { get; set; }
        public int? SettingKindId { get; set; }
        public string SettingValue { get; set; }
        //SettingKinds
        public string KindName { get; set; }
        public string Description { get; set; }
        //DeviceTypes
        public int? TypeId { get; set; }
        public string TypeName { get; set; }
        public string TypeDescription { get; set; }
    }
}
