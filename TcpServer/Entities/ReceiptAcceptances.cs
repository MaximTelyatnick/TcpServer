using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TVM_WMS.SERVER.Entities
{
    public class ReceiptAcceptances
    {
        [Key]
        public int AcceptanceId { get; set; }
        public int OrderId { get; set; }
        public int ReceiptId { get; set; }
        public decimal Quantity { get; set; }
        public int StatusId { get; set; }
        public string PartNumber { get; set; }

        [ForeignKey("OrderId")]
        public Orders Orders { get; set; }

        [ForeignKey("ReceiptId")]
        public Receipts Receipts { get; set; }
    }
}
