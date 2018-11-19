using TVM_WMS.SERVER.Infrastructure;

namespace TVM_WMS.SERVER.DTO
{
    public class UnitsDTO : ObjectBase
    {
        public int UnitId { get; set; }
        public string UnitCode { get; set; }
        public string UnitFullName { get; set; }
        public string UnitLocalName { get; set; }
        public string UnitInternationalName { get; set; }
    }
}
