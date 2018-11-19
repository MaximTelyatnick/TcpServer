using TVM_WMS.SERVER.Infrastructure;

namespace TVM_WMS.SERVER.DTO
{
    public class MaterialGroupsDTO : ObjectBase
    {
        public short MaterialGroupId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public short? ParentId { get; set; }
    }
}
