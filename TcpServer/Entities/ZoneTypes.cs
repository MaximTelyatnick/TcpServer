using System.ComponentModel.DataAnnotations;

namespace TVM_WMS.SERVER.Entities
{
    public class ZoneTypes
    {
        [Key]
        public int ZoneTypeId { get; set; }
        public string ZoneTypeName { get; set; }
    }
}
