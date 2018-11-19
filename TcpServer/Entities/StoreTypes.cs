using System.ComponentModel.DataAnnotations;

namespace TVM_WMS.SERVER.Entities
{
    public class StoreTypes
    {
        [Key]
        public int StoreTypeId { get; set; }
        public string StoreTypeName { get; set; }
    }
}
