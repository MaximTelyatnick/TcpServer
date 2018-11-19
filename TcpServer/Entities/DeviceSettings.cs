using System;
using System.ComponentModel.DataAnnotations;

namespace TVM_WMS.SERVER.Entities
{
    public class DeviceSettings
    {
        [Key]
        public int Id { get; set; }
        public int DeviceId { get; set; }
        public int SettingKindId { get; set; }
        public string SettingValue { get; set; }
    }
}
