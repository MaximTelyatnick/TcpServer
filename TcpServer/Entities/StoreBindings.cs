using System;
using System.ComponentModel.DataAnnotations;

namespace TVM_WMS.SERVER.Entities
{
    public class StoreBindings
    {
        [Key]
        public int Id { get; set; }
        public int StoreNameId { get; set; }
        public int DeviceBindingId { get; set; }
    }
}
