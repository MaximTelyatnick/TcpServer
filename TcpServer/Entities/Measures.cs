using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TVM_WMS.SERVER.Entities
{
    public class Measures
    {
        [Key]
        public int MeasureId { get; set; }
        public decimal Height { get; set; }
        public decimal Width { get; set; }
        public decimal Length { get; set; }
        public decimal UnitWeight { get; set; }
        public int? UnitId { get; set; }
        public int? PackingTypeId { get; set; }

        [ForeignKey("UnitId")]
        public Units Units { get; set; }

        [ForeignKey("PackingTypeId")]
        public PackingTypes PackingTypes { get; set; }

    }
}
