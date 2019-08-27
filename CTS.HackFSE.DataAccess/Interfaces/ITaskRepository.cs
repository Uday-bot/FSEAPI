using CTS.HackFSE.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTS.HackFSE.DataAccess.Interfaces
{
    public interface ITaskRepository
    {

        List<Task> GetAllTask(string sortbycolumn = "", string serachBy = "");

        bool DeleteTask(int taskId);

        Task GetByTaskId(int taskId);

        bool UpdateTask(int Id, Task taskInfo);

        bool EndTask(int Id);

        bool CreateTask(Task taskInfo);

        bool CreateParentTask(ParentTask parentTaskInfo);

        List<ParentTask> GetAllParentTask(string sortbycolumn = "", string serachBy = "");

        List<Task> GetTaskByProjectId(int projectId);

        Task GetTaskbyTaskId(int taskId);
    }
}
