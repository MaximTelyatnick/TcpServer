using System;
using TVM_WMS.SERVER.DTO;
using TVM_WMS.SERVER.Infrastructure;

namespace TVM_WMS.BLL.DTO
{
   public class OrdersDTO : ObjectBase
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? ContractorId { get; set; }
        public int? StatusId { get; set; }


        public string ContractorName { get; set; }
        public string StatusName { get; set; }
        public string Checked { get; set; }
    }
}
