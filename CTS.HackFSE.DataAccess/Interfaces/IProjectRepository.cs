using CTS.HackFSE.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTS.HackFSE.DataAccess.Interfaces
{
    public interface IProjectRepository
    {
        Project GetById(int projectId);

        bool CreateProject(Project project);

        bool UpdateProject(int id, Project projectInfo);

        List<Project> GetAllProject(string sortbycolumn = "", string serachBy = "");

        bool DeleteProject(int projectId);
    }
}
