using CTS.HackFSE.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTS.HackFSE.DataAccess.Interfaces
{
    public interface IUserRepository
    {
        bool CreateUser(User userInfo);

        bool UpdateUser(int Id, User userInfo);

        bool DeleteUser(int userId);

        List<User> GetAllUser(string sortbycolumn = "", string serachBy = "");

        List<User> SortUsers(string sortOrder, string sortBy);

        User GetById(int userId);

    }
}
