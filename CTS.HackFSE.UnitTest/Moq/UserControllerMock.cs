using CTS.HackFSE.Business.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTS.HackFSE.UnitTest.Moq
{
    public static class UserControllerMock
    {

        public static List<UserInfoDTO> GetUsers()
        {
            List<UserInfoDTO> users = new List<UserInfoDTO>();

            UserInfoDTO user1 = new UserInfoDTO()
            {
                EmployeeID = 1,
                FirstName = "Satheesh",
                LastName = "Kandhasamy",
                UserID = 1
            };

            UserInfoDTO user2 = new UserInfoDTO()
            {
                EmployeeID = 2,
                FirstName = "Saravanan",
                LastName = "Seetharaman",
                UserID = 2
            };

            users.Add(user1);
            users.Add(user2);
            return users;

        }

        public static List<UserInfoDTO> GetUsersByName(string name)
        {
            return GetUsers().Where(x => x.FirstName.Equals(name)).ToList();
        }
    }
}
