using System;
using System.ComponentModel.DataAnnotations;

namespace TVM_WMS.SERVER.Entities
{
    public class Devices
    {
        [Key]
        public int Id { get; set; }
        public int TypeId { get; set; }
        public string Name { get; set; }
        public string LocalCPUID { get; set; }
    }
}
