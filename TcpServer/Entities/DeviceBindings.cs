using System.ComponentModel.DataAnnotations;

namespace TVM_WMS.SERVER.Entities
{
    public class DeviceBindings
    {
        [Key]
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public int DeviceId { get; set; }
    }
}
