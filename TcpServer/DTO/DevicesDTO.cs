using System;

namespace TVM_WMS.SERVER.DTO
{
    public class DevicesDTO
    {
        public int Id { get; set; }
        public int? TypeId { get; set; }
        public string Name { get; set; }
        public string LocalCPUID { get; set; }
    }
}
