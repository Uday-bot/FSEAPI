using CTS.HackFSE.Business.DTO;
using CTS.HackFSE.Business.Implementation;
using CTS.HackFSE.Business.Interfaces;
using CTS.HackFSE.Service.Controllers;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CTS.HackFSE.UnitTest
{
   public class TaskControllerTest
    {

        [Fact]

        public void GetTaskById_OkTest()
        {
            int taskId = 1;

            var output = TaskControllerMock.GetTask();

            //Get Mock Repository object
            var taskRepositoryMock = new Mock<ITaskBO>();


            //Setup mock object and return mock output
            taskRepositoryMock
               .Setup(m => m.GetTaskbyTaskId(It.IsAny<int>()))
               .Returns(output);            

            //Invoke controller method
            TaskController controller = new TaskController(taskRepositoryMock.Object);

            var value = controller.GetTaskByTaskId(taskId);

            Assert.NotNull(value);
            Assert.IsType<TaskDTO>(value);
            Assert.Equal("task1", (value.TaskName));
            Assert.Equal(1, (value.Task_ID));


        }

        [Fact]
        public void GetTaskByProjectId_OkTest()
        {
            int projectId = 1;

            var output = TaskControllerMock.GetTaskbyProjectid(projectId);

            //Get Mock Repository object
            var taskRepositoryMock = new Mock<ITaskBO>();


            //Setup mock object and return mock output
            taskRepositoryMock
               .Setup(m => m.GetTaskByProjectId(It.IsAny<int>()))
               .Returns(output);
            

            //Invoke controller method
            TaskController controller = new TaskController(taskRepositoryMock.Object);

            var value = controller.GetTaskByProject(projectId);

            Assert.NotNull(value);
            Assert.IsType<List<TaskDTO>>(value);
            Assert.Equal("task1", (value[0].TaskName));
            Assert.Equal(1, (value[0].Task_ID));
        }
    }
}
