using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TVM_WMS.SERVER.Entities
{
    public class CellZones
    {
        [Key]
        public int CellZoneId { get; set; }
        public int WareHouseId { get; set; }
        public int ZoneNameId { get; set; }

        [ForeignKey("WareHouseId")]
        public WareHouses WareHouses { get; set; }

        [ForeignKey("ZoneNameId")]
        public StorageGroupZones ZoneNames { get; set; }
    }
}
