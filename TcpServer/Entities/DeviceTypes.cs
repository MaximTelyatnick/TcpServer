using System;
using System.ComponentModel.DataAnnotations;

namespace TVM_WMS.SERVER.Entities
{
    public class DeviceTypes
    {
        [Key]
        public int Id { get; set; }
        public string TypeName { get; set; }
        public string TypeDescription { get; set; }
    }
}
