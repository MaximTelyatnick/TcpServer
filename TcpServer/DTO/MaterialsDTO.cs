
using TVM_WMS.SERVER.DTO;
using TVM_WMS.SERVER.Infrastructure;

namespace TVM_WMS.SERVER.DTO
{
    public class MaterialsDTO : ObjectBase
    {
        public int MaterialId { get; set; }
        public string Article { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public short? MaterialGroupId { get; set; }
        public string GroupName { get; set; }
        public int? StorageGroupId { get; set; }
        public string StorageGroupName { get; set; }
        
        
    }
}