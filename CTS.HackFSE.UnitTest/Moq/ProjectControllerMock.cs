using CTS.HackFSE.Business.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTS.HackFSE.UnitTest.Moq
{
    public static class ProjectControllerMock
    {
        public static ProjectDTO GetProject()
        {
            ProjectDTO project = new ProjectDTO()
            {
                EndDate = new DateTime(2019, 12, 12),
                ManagerName = "Udhaya",
                Priority = 10,
                ProjectId = 1,
                ProjectName = "ACES20",
                StartDate = new DateTime(2019, 01, 01),
                UserId = 10
            };
            return project;

        }

        public static List<ProjectDTO> GetAllProject()
        {
            ProjectDTO project1 = new ProjectDTO()
            {
                EndDate = new DateTime(2019, 12, 12),
                ManagerName = "Satheesh",
                Priority = 10,
                ProjectId = 1,
                ProjectName = "ACES20",
                StartDate = new DateTime(2019, 01, 01),
                UserId = 10
            };


            ProjectDTO project2 = new ProjectDTO()
            {
                EndDate = new DateTime(2019, 12, 12),
                ManagerName = "Saravanan",
                Priority = 10,
                ProjectId = 2,
                ProjectName = "ACES",
                StartDate = new DateTime(2019, 04, 01),
                UserId = 10
            };

            List<ProjectDTO> listProject = new List<ProjectDTO>();
            listProject.Add(project1);
            listProject.Add(project2);
            return listProject;

        }
    }
}
