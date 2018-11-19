using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TVM_WMS.SERVER.Entities
{
    public class UserTasks
    {
        [Key]
        public int UserTaskId { get; set; }
        public int TaskId { get; set; }
        public int UserRoleId { get; set; }
        public int AccessRightId { get; set; }

 
    }
}
