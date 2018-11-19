using System;

namespace TVM_WMS.SERVER.DTO
{
    public class HistoryKeepingsDTO
    {
        public int Id { get; set; }
        public int KeepingId { get; set; }
        public int WareHouseId { get; set; }
        public int ReceiptAcceptanceId { get; set; }
        public decimal Quantity { get; set; }
        public int UserId { get; set; }
        public DateTime DateAdded { get; set; }

        public int? NumberCell { get; set; }
        public int? StoreNameId { get; set; }
        public int? StoreNameParentId { get; set; }

        public string UserName { get; set; }
        public string Name { get; set; }
        public string Article { get; set; }
        public string UnitLocalName { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }
    }
}
