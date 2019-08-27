using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;
using CTS.HackFSE.UnitTest.Moq;
using Moq;
using CTS.HackFSE.Service.Controllers;
using CTS.HackFSE.Business.Interfaces;
using CTS.HackFSE.Business.DTO;

namespace CTS.HackFSE.UnitTest
{
    public class UserControllerTest
    {
        
        [Fact]
        public void  GetAllUser_OkTest()
        {

            var output = UserControllerMock.GetUsers();

            //Get Mock Repository object.
            var userRepositoryMock = new Mock<IUserInfoBO>();


            //Setup mock object and return mock output
            userRepositoryMock
               .Setup(m => m.GetAllUser("",""))
               .Returns(output);



            //Invoke controller method
            UserController controller = new UserController(userRepositoryMock.Object);

            var value = controller.Get();

            Assert.NotNull(value);
            Assert.IsType<List<UserInfoDTO>>(value);
            Assert.Equal(1, (value[0].EmployeeID));
            Assert.Equal("Satheesh", (value[0].FirstName));
            Assert.Equal(2, (value[1].EmployeeID));
            Assert.Equal("Saravanan", (value[1].FirstName));

        }


        [Fact]
        public void GetUserByName_OkTest()
        {
            string name = "Satheesh";
            var output = UserControllerMock.GetUsersByName(name);

            //Get Mock Repository object
            var userRepositoryMock = new Mock<IUserInfoBO>();


            //Setup mock object and return mock output
            userRepositoryMock
               .Setup(m => m.GetAllUser("", name))
               .Returns(output);



            //Invoke controller method
            UserController controller = new UserController(userRepositoryMock.Object);

            var value = controller.Get(name,"");

            Assert.NotNull(value);
            Assert.IsType<List<UserInfoDTO>>(value);
            Assert.Equal(1, (value[0].EmployeeID));
            Assert.Equal("Satheesh", (value[0].FirstName));
           

        }
    }
}
