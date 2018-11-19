using System;

namespace TVM_WMS.BLL.DTO.QueryDTO
{
    public class CellPresenceDTO
    {
        public int KeepingId { get; set; }
        public int WareHouseId { get; set; }
        public int ReceiptAcceptanceId { get; set; }
        public int ReceiptId { get; set; }
        public int OrderId { get; set; }
        public decimal QuantityKeeping { get; set; }
        public decimal QuantityChanged { get; set; }
        public decimal QuantityStore { get; set; }
        public string Article { get; set; }
        public string MaterialName { get; set; }
        public int MaterialId { get; set; }
        public string UnitLocalName { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }

        public decimal OldWeight { get; set; }
        public decimal CurrentWeight { get; set; }
    }
}
