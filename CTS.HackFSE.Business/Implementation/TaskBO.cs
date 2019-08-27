using CTS.HackFSE.Business.DTO;
using CTS.HackFSE.Business.Interfaces;
using CTS.HackFSE.DataAccess.Entity;
using CTS.HackFSE.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTS.HackFSE.Business.Implementation
{
    public class TaskBO : ITaskBO
    {
        private readonly ITaskRepository _taskRepository;
        public TaskBO(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        
        bool ITaskBO.EndTask(int Id)
        {
            return _taskRepository.EndTask(Id);
        }

        bool ITaskBO.CreateTask(TaskDTO taskInfo)
        {
            if (taskInfo.IsParentTaskSelected)
            {
                ParentTask parentTask = new ParentTask()
                {
                    Parent_Task = taskInfo.TaskName
                };
                return _taskRepository.CreateParentTask(parentTask);
            }
            else
            {
                return _taskRepository.CreateTask(new Task()
                {
                    EndDate = taskInfo.EndDate,
                    StartDate = taskInfo.StartDate,
                    Parent_ID = taskInfo.Parent_ID,
                    ProjectId = taskInfo.ProjectId,
                    Status = taskInfo.Status,
                    PriorityValue = taskInfo.PriorityValue,
                    TaskName = taskInfo.TaskName,
                });
            }
        }

        List<TaskDTO> ITaskBO.GetTaskByProjectId(int projectId)
        {
            var taskEntities = _taskRepository.GetTaskByProjectId(projectId);

            List<TaskDTO> tasks = new List<TaskDTO>();

            foreach (var task in taskEntities)
            {
                tasks.Add(new TaskDTO()
                {
                    ProjectId = task.ProjectId,
                    Task_ID = task.Task_ID,
                    TaskName = task.TaskName,
                    StartDate = task.StartDate,
                    EndDate = task.EndDate,
                    Parent_ID = task.Parent_ID,
                    PriorityValue = task.PriorityValue,
                    Status = task.Status,
                    ParentTask = task.ParentTask == null? null : new ParentTaskDTO() { Parent_ID = task.ParentTask.Parent_ID, Parent_Task = task.ParentTask.Parent_Task }
                });
            }

            return tasks;
        }

        TaskDTO ITaskBO.GetTaskbyTaskId(int taskId)
        {
            var taskEntity = _taskRepository.GetTaskbyTaskId(taskId);


            TaskDTO task = new TaskDTO()
            {
                ProjectId = taskEntity.ProjectId,
                Task_ID = taskEntity.Task_ID,
                TaskName = taskEntity.TaskName,
                StartDate = taskEntity.StartDate,
                EndDate = taskEntity.EndDate,
                Parent_ID = taskEntity.Parent_ID,
                PriorityValue = taskEntity.PriorityValue,
                Status = taskEntity.Status
            };

            return task;
        }

        List<TaskDTO> ITaskBO.GetAllTask(string sortbycolumn = "", string serachBy = "")
        {
            var taskEntities = _taskRepository.GetAllTask(sortbycolumn, serachBy);
            List<TaskDTO> tasks = new List<TaskDTO>();

            foreach (var task in taskEntities)
            {
                tasks.Add(new TaskDTO()
                {
                    ProjectId = task.ProjectId,
                    Task_ID = task.Task_ID,
                    TaskName = task.TaskName,
                    StartDate = task.StartDate,
                    EndDate = task.EndDate,
                    Parent_ID = task.Parent_ID,
                    PriorityValue = task.PriorityValue,
                    Status = task.Status
                });
            }

            return tasks;
        }

        List<ParentTaskDTO> ITaskBO.GetAllParentTask(string sortbycolumn, string serachBy)
        {
            var taskEntities = _taskRepository.GetAllParentTask(sortbycolumn, serachBy);

            List<ParentTaskDTO> tasks = new List<ParentTaskDTO>();

            foreach (var task in taskEntities)
            {
                tasks.Add(new ParentTaskDTO()
                {
                     Parent_ID = task.Parent_ID,
                     Parent_Task = task.Parent_Task
                });
            }

            return tasks;
        }

        bool ITaskBO.UpdateTask(int id, TaskDTO taskInfo)
        {
            return _taskRepository.UpdateTask(id, new Task()
            {
                ProjectId = taskInfo.ProjectId,
                Task_ID = taskInfo.Task_ID,
                TaskName = taskInfo.TaskName,
                StartDate = taskInfo.StartDate,
                EndDate = taskInfo.EndDate,
                Parent_ID = taskInfo.Parent_ID,
                PriorityValue = taskInfo.PriorityValue,
                Status = taskInfo.Status
            });
        }
    }
}
