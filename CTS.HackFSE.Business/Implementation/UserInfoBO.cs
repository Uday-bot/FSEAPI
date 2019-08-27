using CTS.HackFSE.Business.DTO;
using CTS.HackFSE.Business.Interfaces;
using CTS.HackFSE.DataAccess.Entity;
using CTS.HackFSE.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTS.HackFSE.Business.Implementation
{
    public class UserInfoBO : IUserInfoBO
    {
        private readonly IUserRepository _userInfoRepo;
        public UserInfoBO(IUserRepository userInfoRepo)
        {
            _userInfoRepo = userInfoRepo;
        }
        bool IUserInfoBO.CreateUser(UserInfoDTO userInfo)
        {
            return _userInfoRepo.CreateUser(new User()
            {
                Employee_ID = userInfo.EmployeeID,
                FirstName = userInfo.FirstName,
                LastName = userInfo.LastName,
                UserId = userInfo.UserID
            });
        }

        bool IUserInfoBO.DeleteUser(int userId)
        {
            return _userInfoRepo.DeleteUser(userId);
        }

        List<UserInfoDTO> IUserInfoBO.GetAllUser(string sortbycolumn, string serachBy)
        {
            var userEntities = _userInfoRepo.GetAllUser(sortbycolumn, serachBy);
            List<UserInfoDTO> userList = new List<UserInfoDTO>();
            foreach (var userInfo in userEntities)
            {
                userList.Add(new UserInfoDTO()
                {
                    EmployeeID = userInfo.Employee_ID,
                    FirstName = userInfo.FirstName,
                    LastName = userInfo.LastName,
                    UserID = userInfo.UserId
                });
            }
            return userList;
        }

        UserInfoDTO IUserInfoBO.GetById(int userId)
        {
            var userEntity = _userInfoRepo.GetById(userId);
            return new UserInfoDTO()
            {
                EmployeeID = userEntity.Employee_ID,
                FirstName = userEntity.FirstName,
                LastName = userEntity.LastName,
                UserID = userEntity.UserId
            };
        }

        List<UserInfoDTO> IUserInfoBO.SortUsers(string sortOrder, string sortBy)
        {
            var userEntities = _userInfoRepo.SortUsers(sortOrder, sortBy);
            List<UserInfoDTO> userList = new List<UserInfoDTO>();
            foreach (var userInfo in userEntities)
            {
                userList.Add(new UserInfoDTO()
                {
                    EmployeeID = userInfo.Employee_ID,
                    FirstName = userInfo.FirstName,
                    LastName = userInfo.LastName,
                    UserID = userInfo.UserId
                });
            }
            return userList;
        }

        bool IUserInfoBO.UpdateUser(int id, UserInfoDTO userInfo)
        {
            return _userInfoRepo.UpdateUser(id, new User()
            {
                Employee_ID = userInfo.EmployeeID,
                FirstName = userInfo.FirstName,
                LastName = userInfo.LastName,
                UserId = userInfo.UserID
            });
        }
    }
}
