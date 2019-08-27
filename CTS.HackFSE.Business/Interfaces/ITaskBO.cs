using CTS.HackFSE.Business.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTS.HackFSE.Business.Interfaces
{
    public interface ITaskBO
    {
        bool EndTask(int id);
        bool CreateTask(TaskDTO taskInfo);
        List<TaskDTO> GetTaskByProjectId(int projectId);
        TaskDTO GetTaskbyTaskId(int taskId);
        List<TaskDTO> GetAllTask(string sortbycolumn = "", string serachBy = "");
        List<ParentTaskDTO> GetAllParentTask(string sortbycolumn = "", string serachBy = "");
        bool UpdateTask(int id, TaskDTO taskInfo);
    }

}
