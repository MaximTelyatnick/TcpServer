
namespace TVM_WMS.SERVER.DTO
{
    public class RequirementMaterialsDTO
    {
        public int RequirementMaterialId { get; set; }
        public int RequirementOrderId { get; set; }
        public int MaterialId { get; set; }
        public decimal RequiredQuantity { get; set; }
        public int UnitId { get; set; }

        public string Article { get; set; }
        public string Name { get; set; }
        public int? Changes { get; set; }
        public string UnitLocalName { get; set; }
        public decimal QuantityStore { get; set; }
        
    }
}
