using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TVM_WMS.SERVER.Entities
{
    public class Receipts
    {
        [Key]
        public int ReceiptId { get; set; }
        public int OrderId { get; set; }
        public int MaterialId { get; set; }
        public int ? UnitId { get; set; }
        public decimal Quantity{ get; set; }
        public decimal TotalPrice { get; set; }
        public decimal UnitPrice { get; set; }
        public int? StatusId { get; set; }
        public DateTime? DateProduction { get; set; }
        public DateTime? DateExpiration { get; set; }

        [ForeignKey("OrderId")]
        public Orders Orders { get; set; }

        [ForeignKey("MaterialId")]
        public Materials Materials { get; set; }

        [ForeignKey("UnitId")]
        public Units Units { get; set; }
    }

}
