using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TVM_WMS.SERVER.Entities
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Fio { get; set; }
        public int UserRoleId { get; set; }

        [ForeignKey("UserRoleId")]
        public UserRoles UserRoles { get; set; }
    }
}
