using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TVM_WMS.SERVER.Entities
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public int? ContractorId { get; set; }
        public int? StatusId { get; set; }

        [ForeignKey("ContractorId")]
        public Contractors Contractors { get; set; }
    }
}
