using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CTS.HackFSE.Business.DTO;
using CTS.HackFSE.Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CTS.HackFSE.Service.Controllers
{
    [Produces("application/json")]
    [Route("api/Project")]
    public class ProjectController : Controller
    {
        private readonly IProjectBO _projectBO;
        public ProjectController(IProjectBO projectBO)
        {
            _projectBO = projectBO;
        }

        [HttpGet]
        [Route("Get")]
        public List<ProjectDTO> Get()
        {
            return _projectBO.GetAllProject("", "");
        }

        [HttpGet("{projectId}")]
        public ProjectDTO GetByProjectId(int projectId)
        {
            return _projectBO.GetById(projectId);
        }

        [HttpPost]
        [Route("InsertProject")]
        public bool Post([FromBody] ProjectDTO project)
        {
            return _projectBO.CreateProject(project);
        }

        [HttpPost]
        [Route("UpdateProject")]
        public bool Put(int Id, [FromBody] ProjectDTO projectInfo)
        {
            if (Id != projectInfo.ProjectId)
            {
                throw new ArgumentException();
            }
            return _projectBO.UpdateProject(Id, projectInfo);
        }

        [HttpPost]
        [Route("DeleteProject")]
        public bool Delete(int Id)
        {
            var project = _projectBO.GetById(Id);

            if (project == null)
            {
                throw new ArgumentException();
            }
            return _projectBO.DeleteProject(Id);
        }

    }
}