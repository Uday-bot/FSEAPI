using CTS.HackFSE.Business.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTS.HackFSE.Business.Interfaces
{
    public interface IUserInfoBO
    {
        bool CreateUser(UserInfoDTO userInfo);

        bool UpdateUser(int id, UserInfoDTO userInfo);

        bool DeleteUser(int userId);

        List<UserInfoDTO> GetAllUser(string sortbycolumn = "", string serachBy = "");

        List<UserInfoDTO> SortUsers(string sortOrder, string sortBy);

        UserInfoDTO GetById(int userId);
    }
}
