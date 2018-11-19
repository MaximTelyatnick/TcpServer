using System.ComponentModel.DataAnnotations;

namespace TVM_WMS.SERVER.Entities
{
    public class AccessRights
    {
         [Key]
        public int RightId { get; set; }
        public string RightAttribute { get; set; }
        public string RightName { get; set; }
    }
}
