
using System.ComponentModel.DataAnnotations;
namespace TVM_WMS.SERVER.Entities
{
    public class PlcTypes
    {
        [Key]
        public int Id { get; set; }
        public string TypeName { get; set; }
        public string AliasName { get; set; }
    }
}
