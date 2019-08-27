using System;
using Xunit;
using Moq;
using CTS.HackFSE.UnitTest.Moq;
using System.Collections.Generic;
using CTS.HackFSE.Service.Controllers;
using CTS.HackFSE.Business.Interfaces;
using CTS.HackFSE.Business.DTO;

namespace CTS.HackFSE.UnitTest
{
    public class ProjectControllerTest
    {
       [Fact]      

        public void GetProjectsById_OkTest()
        {
            int projectid = 1;

            var output = ProjectControllerMock.GetProject();

            //Get Mock Repository object
            var ProjectRepositoryMock = new Mock<IProjectBO>();


            //Setup mock object and return mock output
            ProjectRepositoryMock
               .Setup(m => m.GetById(It.IsAny<int>()))
               .Returns(output);         



            //Invoke controller method
            ProjectController controller = new ProjectController(ProjectRepositoryMock.Object);

            var value = controller.GetByProjectId(projectid);


            Assert.NotNull(value);
            Assert.IsType<ProjectDTO>(value);
            Assert.Equal("Satheesh", (value.ManagerName));
            Assert.Equal(1, (value.ProjectId));


           

        }



        [Fact]
        public void Get_OkTest()
        {


            var output = ProjectControllerMock.GetAllProject();

            //Get Mock Repository object
            var ProjectRepositoryMock = new Mock<IProjectBO>();


            //Setup mock object and return mock output
            ProjectRepositoryMock
               .Setup(m => m.GetAllProject("",""))
               .Returns(output);



            //Invoke controller method
            ProjectController controller = new ProjectController(ProjectRepositoryMock.Object);

            var value = controller.Get();

            Assert.NotNull(value);
            Assert.IsType<List<ProjectDTO>>(value);
            Assert.Equal(2, (value.Count));
            Assert.Equal(1, (value[0].ProjectId));
            Assert.Equal(2, (value[1].ProjectId));


          
        }
    }
}
