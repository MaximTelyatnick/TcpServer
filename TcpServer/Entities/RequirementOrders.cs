using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TVM_WMS.SERVER.Entities
{
    public class RequirementOrders
    {
        [Key]
        public int RequirementOrderId { get; set; }
        public string RequirementNumber { get; set; }
        public DateTime RequirementDate { get; set; }
        public int? ResponsiblePersonId { get; set; }

        [ForeignKey("ResponsiblePersonId")]
        public Persons Persons { get; set; }
    }
}
