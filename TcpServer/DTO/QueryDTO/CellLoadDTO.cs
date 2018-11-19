
namespace TVM_WMS.BLL.DTO.QueryDTO
{
    public class CellLoadDTO
    {
        public int WareHouseId { get; set; }
        public int StoreNameId { get; set; }
        public decimal CellFullWeight { get; set; }
        public decimal CellCurrentWeight { get; set; }
        public decimal CellLoad { get; set; }
    }
}
