using System;
using TVM_WMS.SERVER.Infrastructure;

namespace TVM_WMS.SERVER.DTO
{
    public class ReceiptsDTO : ObjectBase
    {
        public int ReceiptId { get; set; }
        public int OrderId { get; set; }
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
        public bool IsFilled{ get; set; }
        public int OrderStatusId { get; set; }
        public string OrderStatusName { get; set; }
        public int? ContractorId { get; set; }
        public string ContractorName { get; set; }

        public int MaterialEntryStatus { get; set; }
    }
}
