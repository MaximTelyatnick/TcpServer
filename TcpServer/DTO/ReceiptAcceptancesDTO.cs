
using System;

namespace TVM_WMS.SERVER.DTO
{
    public class ReceiptAcceptancesDTO
    {
        public int AcceptanceId{ get; set; }
        public int OrderId { get; set; }
        public int ReceiptId { get; set; }
        public decimal Quantity { get; set;}
        public string UnitLocalName { get; set; }
        public int StatusId { get; set; }

        public int MaterialId { get; set; }
        public string Name { get; set; }
        public string Article { get; set; }
        public string StatusName { get; set; }
        public string OrderNumber { get; set; }
        // [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime OrderDate { get; set; }
        public DateTime? DateProduction { get; set; }
        public DateTime? DateExpiration { get; set; }
        public string BarCodeText { get; set; }
        public string ContractorName { get; set; }
        public string PartNumber { get; set; }
    }
}
