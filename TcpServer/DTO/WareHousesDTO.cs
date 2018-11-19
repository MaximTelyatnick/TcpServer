
namespace TVM_WMS.SERVER.DTO
{
    public class WareHousesDTO
    {
        public int WareHouseId { get; set; }
        public int StoreNameId { get; set; }
        public int? NumberCell { get; set; }
        public string NumberCellString { get; set; }
        public string NameCell { get; set; }
        public int? MeasureId { get; set; }
        public bool Checked { get; set; }
        public int? Percent { get; set; }
        //for cell info
        public decimal? UnitWeight { get; set; }
        public decimal? Height { get; set; }
        public decimal? Width { get; set; }
        public decimal? Length { get; set; }
        public string RowName { get; set; }
        public string StoreName { get; set; }
        //for zone info
        public int? CellZoneId { get; set; }
        public int? ZoneNameId { get; set; }
        public string ZoneColor { get; set; }
        public string ZoneName { get; set; }

        public int? UnitId { get; set; }
        public string UnitLocalName { get; set; }
        
        public int? StorageGroupId { get; set; }
        public string StorageGroupName { get; set; }

        public int? LoadingStatusId { get; set; }
        public decimal? MaxWeight { get; set; }
        public decimal? CurrentWeight { get; set; }
        public decimal? RemainsWeight { get; set; }
        public decimal? CellLoad { get; set; }
    }
}
