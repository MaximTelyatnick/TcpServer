using System.ComponentModel.DataAnnotations;

namespace TVM_WMS.SERVER.Entities
{
    public class DeviceBindingSettings
    {
        [Key]
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public int DeviceId { get; set; }
        public int StoreNameId { get; set; }
        public int StoreNameParentId { get; set; }
        //Devices
        public int? TypeId { get; set; }
        public string Name { get; set; }
        //DeviceTypes
        public string TypeName { get; set; }
        //DeviceSettings
        public int? DeviceSettingId { get; set; }
        public int? SettingKindId { get; set; }
        public string SettingValue { get; set; }
        //SettingKinds
        public string KindName { get; set; }
        public string Description { get; set; }
    }
}
