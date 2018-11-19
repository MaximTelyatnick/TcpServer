using System.ComponentModel.DataAnnotations;

namespace TVM_WMS.SERVER.Entities
{
    public class DataItems
    {
        [Key]
        public int Id { get; set; }
        public int DeviceId { get; set; }
        public string Name { get; set; }
        public int ItemTypeId { get; set; }
        public int ParentDeviceId { get; set; }
        public string Offset { get; set; }
        public int CanListen { get; set; }
    }
}
