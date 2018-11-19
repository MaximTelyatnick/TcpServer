using TVM_WMS.SERVER.Infrastructure;

namespace TVM_WMS.SERVER.DTO
{
    public class PersonsDTO : ObjectBase
    {
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public int? ProfessionId { get; set; }
        public string ProfessionName { get; set; }

    }
}
