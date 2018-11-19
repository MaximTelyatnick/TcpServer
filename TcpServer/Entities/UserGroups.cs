using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TVM_WMS.SERVER.Entities
{
    public class UserGroups
    {
        [Key]
        public int UserGroupId { get; set; }
        public string GroupName { get; set; }
        public int UserRightId { get; set; }

        [ForeignKey("UserRightId")]
        public UserRights UserRights { get; set; }
    }
}
