using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TVM_WMS.SERVER.Entities
{
    public class WareHouses
    {
        [Key]
        public int WareHouseId { get; set; }
        public int StoreNameId { get; set; }
        public int? NumberCell { get; set; }
        public string NameCell { get; set; }
        public int? MeasureId { get; set; }
        public int? LoadingStatusId { get; set; }
        public decimal? CurrentWeight { get; set; }
    }
}
