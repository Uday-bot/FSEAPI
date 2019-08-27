using CTS.HackFSE.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTS.HackFSE.Business.DTO
{
    public class TaskDTO
    {
        public int Task_ID { get; set; }
        public Nullable<int> Parent_ID { get; set; }
        public Nullable<int> ProjectId { get; set; }
        public string TaskName { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<int> PriorityValue { get; set; }
        public string Status { get; set; }
        public bool IsParentTaskSelected { get; set; }
        public Project Project { get; set; }
        public ParentTaskDTO ParentTask { get; set; }
    }
}
