using System;
using System.Collections.Generic;
using CTS.HackFSE.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CTS.HackFSE.Business.DTO;

namespace CTS.HackFSE.Service.Controllers
{
    [Produces("application/json")]
    [Route("api/Task")]
    public class TaskController : Controller
    {
        private readonly ITaskBO _taskManager;
        public TaskController(ITaskBO taskManager)
        {
            _taskManager = taskManager;
        }

        [HttpGet]
        [Route("Get")]
        public List<TaskDTO> Get()
        {
            var details = _taskManager.GetAllTask("", "");
            return details;
        }

        [HttpGet]
        [Route("GetParent")]
        public List<ParentTaskDTO> GetParent()
        {
            var details = _taskManager.GetAllParentTask("", "");
            return details;
        }

        [HttpPost]
        [Route("InsertTask")]
        public IActionResult Post([FromBody]TaskDTO taskModel)
        {
            _taskManager.CreateTask(taskModel);
            return Created(Request.Path, taskModel);
        }

        [HttpPost]
        [Route("UpdateTask/{Id}")]
        public bool Put(int Id, [FromBody]TaskDTO taskInfo)
        {
            if (Id != taskInfo.Task_ID)
            {
                throw new ArgumentException();
            }
            return _taskManager.UpdateTask(Id, taskInfo);
        }

        [HttpPost]
        [Route("EndTask/{Id}")]
        public bool Put(int Id)
        {
            if (Id <= 0)
            {
                throw new ArgumentException();
            }
            return _taskManager.EndTask(Id);
        }

        [HttpGet]
        [Route("GetTaskByProject/{projectId}")]
        public List<TaskDTO> GetTaskByProject(int projectId)
        {
            var details = _taskManager.GetTaskByProjectId(projectId);
            return details;
        }

        [HttpGet]
        [Route("GetTaskByTaskId/{taskId}")]
        public TaskDTO GetTaskByTaskId(int taskId)
        {
            return _taskManager.GetTaskbyTaskId(taskId);
        }
    }
}