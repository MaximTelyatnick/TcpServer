namespace TVM_WMS.SERVER.DTO
{
    public class ConfirmQuantityDTO
    {
        public int? KeepingId { get; set; }
        public int ReceiptAcceptanceId { get; set; }
        public string Article { get; set; }
        public string MaterialName { get; set; }
        public string UnitLocalName { get; set; }
        public decimal Quantity { get; set; }
        public decimal OldWeight { get; set; }
        public decimal CurrentWeight { get; set; }
    }
}
