using System;
using System.ComponentModel.DataAnnotations;

namespace TVM_WMS.SERVER.Entities
{
    public class StoreSettings
    {
        [Key]
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string SettingName { get; set; }
        public int DataArea { get; set; }
    }
}
