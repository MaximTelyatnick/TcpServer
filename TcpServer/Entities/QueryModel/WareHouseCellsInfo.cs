using System.ComponentModel.DataAnnotations;

namespace TVM_WMS.SERVER.Entities
{
    public class WareHouseCellsInfo
    {
        [Key]
        public int WareHouseId { get; set; }
        public int StoreNameId { get; set; }
        public int? NumberCell { get; set; }
        public string NumberCellString { get; set; }
        public string NameCell { get; set; }
        public int? CellZoneId { get; set; }
        public int? ZoneNameId { get; set; }
        public string ZoneColor { get; set; }
        public string ZoneName { get; set; }
        public int? LoadingStatusId { get; set; }
        public decimal? MaxWeight { get; set; }
        public decimal? CurrentWeight { get; set; }
        public decimal? RemainsWeight { get; set; }
        public decimal? CellLoad { get; set; }
    }
}
