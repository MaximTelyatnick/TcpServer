using System;

namespace TVM_WMS.SERVER.DTO
{
    public class UserTasksDTO
    {
        public int UserTaskId { get; set; }
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string TaskCaption { get; set; }
        public int UserRoleId { get; set; }
        public int AccessRightId { get; set; }
        public string RightAttribute { get; set; }
        public string RightName { get; set; }
        public bool CheckForDelete { get; set; }
    }
}
