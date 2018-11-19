using System;
using System.ComponentModel.DataAnnotations;

namespace TVM_WMS.SERVER.Entities
{
    public class DeficitMaterials
    {
        [Key]
        public int Id { get; set; }
        public int MaterialId { get; set; }
        public int UnitId { get; set; }
        public decimal Rate { get; set; }
    }
}
