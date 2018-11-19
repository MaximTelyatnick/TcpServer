using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TVM_WMS.SERVER.Entities
{
    public class RequirementMaterials
    {
        [Key]
        public int RequirementMaterialId { get; set; }
        public int RequirementOrderId { get; set; }
        public int MaterialId { get; set; }
        public decimal RequiredQuantity { get; set; }
        public int UnitId { get; set; }

        [ForeignKey("RequirementOrderId")]
        public RequirementOrders RequirementOrders { get; set; }

        [ForeignKey("MaterialId")]
        public Materials Materials { get; set; }

        [ForeignKey("UnitId")]
        public Units Units { get; set; }
    }
}
