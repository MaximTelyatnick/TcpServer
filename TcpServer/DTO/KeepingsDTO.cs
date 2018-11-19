using System;

namespace TVM_WMS.SERVER.DTO
{
   public class KeepingsDTO
    {
        public int KeepingId { get; set; }
        public int WareHouseId { get; set; }
        public int ReceiptAcceptanceId { get; set; }
        public decimal Quantity { get; set; }
        public DateTime DataAdded { get; set; }
    }
}
