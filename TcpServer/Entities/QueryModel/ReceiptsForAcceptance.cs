using System;
using System.ComponentModel.DataAnnotations;

namespace TVM_WMS.SERVER.Entities
{
    public class ReceiptsForAcceptance
    {
        [Key]
        public int ReceiptId { get; set; }
        public int OrderId { get; set; }
        public int MaterialId { get; set; }
        public int? UnitId { get; set; }
        public decimal Quantity { get; set; }
        public DateTime? DateProduction { get; set; }
        public DateTime? DateExpiration { get; set; }
        public string Name { get; set; }
        public string Article { get; set; }
        public string UnitLocalName { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderStatusId { get; set; }
        public string OrderStatusName { get; set; }
        public string GroupOrder { get; set; }
        public bool Checked { get; set; }
        public bool IsFilled { get; set; }
        public bool MaterialEntryStatus { get; set; }
    }
}
