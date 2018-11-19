using System;
using System.ComponentModel.DataAnnotations;

namespace TVM_WMS.SERVER.Entities
{
    public class GlobalSettings
    {
        [Key]
        public int Id { get; set; }
        public int SettingTypeId { get; set; }
        public int SettingKindId { get; set; }
        public string SettingValue { get; set; }
    }
}
