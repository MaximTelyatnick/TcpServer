using System;

namespace TVM_WMS.SERVER.DTO
{
    public class RequirementOrdersDTO
    {
        public int RequirementOrderId { get; set; }
        public string RequirementNumber { get; set; }
        public DateTime RequirementDate { get; set; }
        public int? ResponsiblePersonId { get; set; }

        public string PersonName { get; set; }
    }
}
