using TVM_WMS.SERVER.Infrastructure;

namespace TVM_WMS.SERVER.DTO
{
    public class DeficitMaterialsDTO : ObjectBase
    {
        public int Id { get; set; }
        public int MaterialId { get; set; }
        public int UnitId { get; set; }
        public decimal Rate { get; set; }
    }
}
