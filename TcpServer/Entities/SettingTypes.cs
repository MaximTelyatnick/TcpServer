using System;
using System.ComponentModel.DataAnnotations;

namespace TVM_WMS.SERVER.Entities
{
    public class SettingTypes
    {
        [Key]
        public int Id { get; set; }
        public string SettingSectionName { get; set; }
    }
}
