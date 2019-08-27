using CTS.HackFSE.Business.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTS.HackFSE.UnitTest
{
   public static class TaskControllerMock
    {

        public static TaskDTO GetTask()
        {
            TaskDTO task = new TaskDTO()
            {
                EndDate = new DateTime(2019, 12, 12),
                Task_ID = 1,
                TaskName = "task1",
                PriorityValue = 10,
                ProjectId = 1,                
                Parent_ID = -1,
                Status = "Completed"                      
            };
            return task;

        }

        public static List<TaskDTO> GetTaskbyProjectid(int projectId)
        {
            TaskDTO task1 = new TaskDTO()
            {
                EndDate = new DateTime(2019, 12, 12),
                Task_ID = 1,
                TaskName = "task1",
                PriorityValue = 10,
                ProjectId = 1,
                Parent_ID = -1,
                Status = "Completed"
            };
            TaskDTO task2 = new TaskDTO()
            {
                EndDate = new DateTime(2019, 12, 12),
                Task_ID = 1,
                TaskName = "task2",
                PriorityValue = 10,
                ProjectId = 1,  
                Parent_ID = -1,
                
                Status = "Progress"
            };
            List<TaskDTO> tasks = new List<TaskDTO>();
            tasks.Add(task1);
            tasks.Add(task2);
            return tasks;
        }
    }
}
