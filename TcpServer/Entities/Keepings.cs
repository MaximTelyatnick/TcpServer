using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TVM_WMS.SERVER.Entities
{
    public class Keepings
    {
        [Key]
        public int KeepingId { get; set; }
        public int WareHouseId { get; set; }
        public int ReceiptAcceptanceId { get; set; }
        public decimal Quantity { get; set; }
        public DateTime DataAdded { get; set; }

        [ForeignKey("ReceiptAcceptanceId")]
        public ReceiptAcceptances ReceiptAcceptances { get; set; }

        [ForeignKey("WareHouseId")]
        public WareHouses WareHouses { get; set; }
    }
}
