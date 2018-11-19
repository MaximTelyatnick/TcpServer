using TVM_WMS.SERVER.DTO;
using TVM_WMS.SERVER.Infrastructure;

namespace TVM_WMS.SERVER.DTO
{
    public class ContractorsDTO : ObjectBase
    {
        public int ContractorId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Srn { get; set; }
        public string Tin { get; set; }
    }
}
