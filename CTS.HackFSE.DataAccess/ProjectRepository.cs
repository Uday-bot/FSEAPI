using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CTS.HackFSE.DataAccess.Interfaces;
using CTS.HackFSE.DataAccess.Entity;

namespace CTS.HackFSE.DataAccess
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly HackFSEContext dbContext;
        public ProjectRepository(HackFSEContext context)
        {
            dbContext = context;
        }
        public bool CreateProject(Project project)
        {
            bool isSave = true;

            dbContext.Projects.Add(project);
            dbContext.Entry(project).State = EntityState.Added;
            dbContext.SaveChanges();

            return isSave;
        }

        public virtual Project GetById(int projectId)
        {

            var projectInfo = dbContext.Projects.Where(x => x.ProjectId == projectId).Include(u => u.UserInfo).FirstOrDefault();
            return projectInfo;
        }

        public bool UpdateProject(int id, Project projectInfo)
        {
            bool isSave = true;

            var project = GetById(id);
            if (projectInfo != null)
            {
                project.ProjectName = projectInfo.ProjectName;
                project.StartDate = projectInfo.StartDate;
                project.EndDate = projectInfo.EndDate;
                project.ManagerName = projectInfo.ManagerName;
                project.Priority = projectInfo.Priority;
                project.UserId = projectInfo.UserId;
            }
            dbContext.Projects.Add(project);
            dbContext.SaveChanges();


            return isSave;
        }

        public List<Project> GetAllProject(string sortbycolumn = "", string serachBy = "")
        {
            List<Project> projects = new List<Project>();

            if (string.IsNullOrEmpty(sortbycolumn))
            {
                sortbycolumn = "ProjectId";
            }
            if (!string.IsNullOrEmpty(serachBy))
            {
                projects = dbContext.Projects.Where(x => x.ProjectName.ToLower().Contains(serachBy.ToLower())).ToList();
            }
            else
            {
                var propertyInfo = typeof(Project).GetProperty(sortbycolumn);
                projects = dbContext.Projects.OrderBy(x => propertyInfo.GetValue(x, null)).ToList();
            }
            return projects;
        }

        public bool DeleteProject(int projectId)
        {

            var entity = dbContext.Projects.FirstOrDefault(u => u.ProjectId == projectId);
            if (entity == null)
            {
                return false;
            }
            else
            {
                dbContext.Projects.Remove(entity);
                dbContext.SaveChanges();
                return true;
            }
        }
    }
}
