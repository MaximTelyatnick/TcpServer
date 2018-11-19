
using TVM_WMS.SERVER.Infrastructure;
namespace TVM_WMS.SERVER.DTO
{
    public class UserRolesDTO : ObjectBase
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
