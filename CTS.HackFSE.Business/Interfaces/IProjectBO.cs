using CTS.HackFSE.Business.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTS.HackFSE.Business.Interfaces
{
    public interface IProjectBO
    {
        ProjectDTO GetById(int projectId);

        bool CreateProject(ProjectDTO project);

        bool UpdateProject(int id, ProjectDTO projectInfo);

        List<ProjectDTO> GetAllProject(string sortbycolumn = "", string serachBy = "");

        bool DeleteProject(int projectId);
    }
}
