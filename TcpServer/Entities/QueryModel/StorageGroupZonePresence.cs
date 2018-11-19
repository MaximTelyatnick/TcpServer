using System;
using System.ComponentModel.DataAnnotations;

namespace TVM_WMS.SERVER.Entities
{
    public class StorageGroupZonePresence
    {
        [Key]
        public int RecId { get; set; }
        public int WareHouseId { get; set; }
        public int StoreNameId { get; set; }
        public int? NumberCell { get; set; }
        public string NameCell { get; set; }
        public int? MeasureId { get; set; }
        public string CellMeasure { get; set; }
        public decimal? MaxWeight { get; set; }
        public decimal? CurrentWeight { get; set; }
        public decimal? FreeWeight { get; set; }
        public string RowName { get; set; }
        public string StoreName { get; set; }
        public int? MaterialId { get; set; }
        public string Article { get; set; }
        public string MaterialName { get; set; }
        public string UnitLocalName { get; set; }
        public decimal? QuantityStore { get; set; }
        public int? LoadingStatusId { get; set; }
        public string LoadingStatusName { get; set; }
        public decimal? CellPresence { get; set; }
        public int? CellZoneId { get; set; }
        public int? ZoneNameId { get; set; }
        public int ZoneTypeId { get; set; }
        public string ZoneTypeName { get; set; }
        public string ZoneName { get; set; }
        public string ZoneColor { get; set; }
    }
}
