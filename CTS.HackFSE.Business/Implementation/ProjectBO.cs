using CTS.HackFSE.Business.DTO;
using CTS.HackFSE.Business.Interfaces;
using CTS.HackFSE.DataAccess.Entity;
using CTS.HackFSE.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTS.HackFSE.Business.Implementation
{
    public class ProjectBO : IProjectBO
    {
        private readonly IProjectRepository _projectRepo;
        public ProjectBO(IProjectRepository projectRepo)
        {
            _projectRepo = projectRepo;
        }
        bool IProjectBO.CreateProject(ProjectDTO project)
        {
            return _projectRepo.CreateProject(new Project()
            {
                ProjectId = project.ProjectId,
                ProjectName = project.ProjectName,
                Priority = project.Priority,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
                ManagerName = project.ManagerName,
                UserId = project.UserId
            });
        }

        bool IProjectBO.DeleteProject(int projectId)
        {
            return _projectRepo.DeleteProject(projectId);
        }

        List<ProjectDTO> IProjectBO.GetAllProject(string sortbycolumn, string serachBy)
        {
            var projectEntities = _projectRepo.GetAllProject(sortbycolumn, serachBy);

            List<ProjectDTO> projects = new List<ProjectDTO>();

            foreach (var project in projectEntities)
            {
                projects.Add(new ProjectDTO()
                {
                    ProjectId = project.ProjectId,
                    ProjectName = project.ProjectName,
                    Priority = project.Priority,
                    StartDate = project.StartDate,
                    EndDate = project.EndDate,
                    ManagerName = project.ManagerName,
                    UserId = project.UserId
                });
            }

            return projects;
        }

        ProjectDTO IProjectBO.GetById(int projectId)
        {
            var project = _projectRepo.GetById(projectId);
            return new ProjectDTO()
            {
                ProjectId = project.ProjectId,
                ProjectName = project.ProjectName,
                Priority = project.Priority,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
                ManagerName = project.ManagerName,
                UserId = project.UserId,
                UserInfo = project.UserInfo != null ? new UserInfoDTO()
                {
                    EmployeeID = project.UserInfo.Employee_ID,
                    FirstName = project.UserInfo.FirstName,
                    LastName = project.UserInfo.LastName,
                    UserID = project.UserInfo.UserId,
                } : null,

            };
        }

        bool IProjectBO.UpdateProject(int id, ProjectDTO projectInfo)
        {
            return _projectRepo.UpdateProject(id, new Project()
            {
                ProjectId = projectInfo.ProjectId,
                ProjectName = projectInfo.ProjectName,
                Priority = projectInfo.Priority,
                StartDate = projectInfo.StartDate,
                EndDate = projectInfo.EndDate,
                ManagerName = projectInfo.ManagerName,
                UserId = projectInfo.UserId
            });
        }
    }
}
