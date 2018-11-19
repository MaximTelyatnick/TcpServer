using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TVM_WMS.SERVER.Entities
{
    public class CellQuantityByZones
    {
        [Key]
        public int RecID { get; set; }
        public int ZoneNameId { get; set; }
        public int StoreNameId { get; set; }
        public string StoreName { get; set; }
        public int CountByRow { get; set; }
        public int CountByEmptyCell { get; set; }
        public int CountByPartlyCell { get; set; }
        public int CountByFullCell { get; set; }

    }
}