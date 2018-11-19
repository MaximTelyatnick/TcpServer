using System;

namespace TVM_WMS.SERVER.DTO
{
    public class ExpendituresDTO
    {
        public int ExpendituresId { get; set; }
        public int ReceiptAcceptanceId { get; set; }
        public int? KeepingId { get; set; }
        public decimal Quantity { get; set; }
        public DateTime ExpDate { get; set; }
        public int? UserId { get; set; }

        public int? WareHouseId { get; set; }
        public int? NumberCell { get; set; }
        public int? StoreNameId { get; set; }
        public int? StoreNameParentId { get; set; }

        public string UserName { get; set; }
        public string Name { get; set; }
        public string Article { get; set; }
        public string UnitLocalName { get; set; }
        public int? MaterialId { get; set; }
        public int? UnitId { get; set; }
    }
}