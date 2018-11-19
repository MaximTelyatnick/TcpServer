using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace TVM_WMS.SERVER.Entities
{
    public class Expenditures
    {
        public int ExpendituresId { get; set; }
        public int ReceiptAcceptanceId { get; set; }
        public int? KeepingId { get; set; }
        public decimal Quantity { get; set; }
        public DateTime ExpDate { get; set; }
        public int? UserId { get; set; }

        [ForeignKey("ReceiptAcceptanceId")]
        public ReceiptAcceptances ReceiptAcceptances { get; set; }

        [ForeignKey("KeepingId")]
        public Keepings Keepings { get; set; }

        [ForeignKey("UserId")]
        public Users Users { get; set; }
    }
}
