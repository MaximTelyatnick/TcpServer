

using TVM_WMS.SERVER.Infrastructure;
namespace TVM_WMS.SERVER.DTO
{
    public class CellQuantityByZonesDTO : ObjectBase
    {
        public int RecID { get; set; }
        public int ZoneNameId { get; set; }
        public int StoreNameId { get; set; }
        public int CountByRow { get; set; }
        public int CountByEmptyCell { get; set; }
        public int CountByPartlyCell { get; set; }
        public int CountByFullCell { get; set; }

        public string StoreName { get; set; }
    }
}
