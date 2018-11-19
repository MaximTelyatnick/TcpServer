
using System;
using TVM_WMS.SERVER.Infrastructure;

namespace TVM_WMS.SERVER.DTO
{
    public class ReceiptsForKeepingDTO : ObjectBase
    {
        public int AcceptanceId { get; set; }
        public int OrderId { get; set; }
        public int ReceiptId { get; set; }
        public int MaterialId { get; set; }
        public int? UnitId { get; set; }
        public decimal Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal UnitPrice { get; set; }
        public int? StatusId { get; set; }
        public DateTime? DateProduction { get; set; }
        public DateTime? DateExpiration { get; set; }

        public string Name { get; set; }
        public string Article { get; set; }
        public string UnitLocalName { get; set; }
        public int? Changes { get; set; }
        public string StatusName { get; set; }
        public string Checked { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string GroupOrder { get; set; }
        public bool IsFilled { get; set; }

        //properties for ReceiptForKeeping
        public int OrderStatusId { get; set; }
        public string OrderStatusName { get; set; }
        public decimal QuantityReceipt { get; set; }
        public decimal QuantityAcceptance { get; set; }
        public decimal QuantityForKeep { get; set; }
        public decimal QuantityForKeepMax { get; set; }
        public int? ContractorId { get; set; }
        public string ContractorName { get; set; }

        public int? StorageGroupId { get; set; }
        public string StorageGroupName { get; set; }
        public int? ZoneNameId { get; set; }
        public string ZoneName { get; set; }
        public int? CellZoneId { get; set; }
        public int StoreNameHeaderId { get; set; }
        public int MaterialEntryStatus { get; set; }
        public int FlagAcceptance { get; set; }
    }
}
