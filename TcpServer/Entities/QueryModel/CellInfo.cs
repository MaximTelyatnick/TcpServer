using System.ComponentModel.DataAnnotations;

namespace TVM_WMS.SERVER.Entities
{
    public class CellInfo
    {
        [Key]
        public int WareHouseId { get; set; }
        public int StoreNameId { get; set; }
        public int NumberCell { get; set; }
        public string NameCell { get; set; }
        public int? MeasureId { get; set; }
        public decimal? UnitWeight { get; set; }
        public decimal? Height { get; set; }
        public decimal? Width { get; set; }
        public decimal? Length { get; set; }
        public string RowName { get; set; }
        public string StoreName { get; set; }
        public int? ZoneNameId { get; set; }
        public string ZoneName { get; set; }
        public string ZoneColor { get; set; }
        public int? UnitId { get; set; }
        public string UnitLocalName { get; set; }
        public int? StorageGroupId { get; set; }
        public string StorageGroupName { get; set; }
        public int? LoadingStatusId { get; set; }
    }
}
