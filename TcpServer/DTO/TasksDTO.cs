﻿using System;

namespace TVM_WMS.SERVER.DTO
{
    public class TasksDTO
    {
        public int TaskId { get; set; }
        public int? ParentId { get; set; }
        public string TaskName { get; set; }
        public string TaskCaption { get; set; }
        public int? UserTaskId { get; set; }
        public bool Checked { get; set; }
        public bool AccessRight { get; set; }
    }
}
