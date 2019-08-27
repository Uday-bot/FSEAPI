using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CTS.HackFSE.DataAccess.Interfaces;
using CTS.HackFSE.DataAccess.Entity;

namespace CTS.HackFSE.DataAccess
{
    public class TaskRepository : ITaskRepository
    {
        private readonly HackFSEContext dbContext;
        public TaskRepository(HackFSEContext context)
        {
            dbContext = context;
        }

        List<Task> ITaskRepository.GetAllTask(string sortbycolumn = "", string serachBy = "")
        {
            List<Task> tasks = new List<Task>();

            if (string.IsNullOrEmpty(sortbycolumn))
            {
                sortbycolumn = "Task_ID";
            }
            if (!string.IsNullOrEmpty(serachBy))
            {

                tasks = dbContext.Tasks.Where(x => x.TaskName.ToLower().Contains(serachBy.ToLower())).Include(p => p.ParentTask).ToList();
            }
            else
            {
                var propertyInfo = typeof(Task).GetProperty(sortbycolumn);
                tasks = dbContext.Tasks.OrderBy(x => propertyInfo.GetValue(x, null)).Include(p => p.ParentTask).ToList();
            }
            return tasks;
        }

        bool ITaskRepository.DeleteTask(int taskId)
        {

            var entity = dbContext.Tasks.FirstOrDefault(u => u.Task_ID == taskId);
            if (entity == null)
            {
                return false;
            }
            else
            {
                dbContext.Tasks.Remove(entity);
                dbContext.SaveChanges();
                return true;
            }
        }

        Task ITaskRepository.GetByTaskId(int taskId)
        {
            var taskInfo = dbContext.Tasks.Where(x => x.Task_ID == taskId).FirstOrDefault();
            return taskInfo;
        }

        bool ITaskRepository.UpdateTask(int Id, Task taskInfo)
        {
            bool isSave = false;

            var task = dbContext.Tasks.Where(x => x.Task_ID == Id).FirstOrDefault();
            if (taskInfo != null)
            {
                task.TaskName = taskInfo.TaskName;
                task.ProjectId = taskInfo.ProjectId;
                task.StartDate = taskInfo.StartDate;
                task.EndDate = taskInfo.EndDate;
                task.Parent_ID = taskInfo.Parent_ID;
                task.PriorityValue = taskInfo.PriorityValue;
                task.Status = taskInfo.Status;
            }
            dbContext.Tasks.Add(task);
            dbContext.Entry(task).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            isSave = dbContext.SaveChanges() > 0;

            return isSave;
        }

        bool ITaskRepository.EndTask(int Id)
        {
            bool isSave = true;

            var task = dbContext.Tasks.Where(x => x.Task_ID == Id).FirstOrDefault();
            if (task != null)
            {
                task.Status = "Completed";
                task.EndDate = DateTime.Now.Date;
            }
            dbContext.Tasks.Add(task);
            dbContext.Entry(task).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            isSave = dbContext.SaveChanges() > 0;

            return isSave;
        }

        bool ITaskRepository.CreateTask(Task taskInfo)
        {
            bool isSave = true;

            dbContext.Tasks.Add(taskInfo);
            dbContext.Entry(taskInfo).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            isSave = dbContext.SaveChanges() > 0;

            return isSave;
        }

        bool ITaskRepository.CreateParentTask(ParentTask parentTaskInfo)
        {
            bool isSave = true;

            dbContext.ParentTasks.Add(parentTaskInfo);
            dbContext.Entry(parentTaskInfo).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            isSave = dbContext.SaveChanges() > 0;

            return isSave;
        }

        List<ParentTask> ITaskRepository.GetAllParentTask(string sortbycolumn = "", string serachBy = "")
        {
            List<ParentTask> parentTasks;

            if (string.IsNullOrEmpty(sortbycolumn))
            {
                sortbycolumn = "Parent_ID";
            }
            if (!string.IsNullOrEmpty(serachBy))
            {
                parentTasks = dbContext.ParentTasks.Where(x => x.Parent_Task.ToLower().Contains(serachBy.ToLower())).ToList();
            }
            else
            {
                var propertyInfo = typeof(ParentTask).GetProperty(sortbycolumn);

                parentTasks = dbContext.ParentTasks.OrderBy(x => propertyInfo.GetValue(x, null)).ToList();
            }
            return parentTasks;

        }

        List<Task> ITaskRepository.GetTaskByProjectId(int projectId)
        {
            return (from task in dbContext.Tasks
                    join pt in dbContext.ParentTasks.DefaultIfEmpty() on task.Parent_ID equals pt.Parent_ID into pt1
                    from pt2 in pt1.DefaultIfEmpty()
                    where task.ProjectId == projectId
                    select new Task()
                    {
                        ProjectId = task.ProjectId,
                        Task_ID = task.Task_ID,
                        TaskName = task.TaskName,
                        StartDate = task.StartDate,
                        EndDate = task.EndDate,
                        Parent_ID = task.Parent_ID,
                        PriorityValue = task.PriorityValue,
                        Status = task.Status,
                        ParentTask = pt2
                    }).ToList();
        }

        Task ITaskRepository.GetTaskbyTaskId(int taskId)
        {
           return dbContext.Tasks.Where(x => x.Task_ID == taskId).Include(p => p.ParentTask).FirstOrDefault();
        }
    }
}

