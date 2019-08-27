using CTS.HackFSE.DataAccess.Entity;
using CTS.HackFSE.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTS.HackFSE.DataAccess
{
    public class UserInfoRepository : IUserRepository
    {
        private readonly HackFSEContext dbContext;
        public UserInfoRepository(HackFSEContext context)
        {
            dbContext = context;

        }

        bool IUserRepository.CreateUser(User userInfo)
        {
            bool isSave = true;

            dbContext.Users.Add(userInfo);
            dbContext.Entry(userInfo).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            isSave = dbContext.SaveChanges() > 0;

            return isSave;
        }

        bool IUserRepository.UpdateUser(int Id, User userInfo)
        {
            bool isSave = true;

            var user = dbContext.Users.Where(x => x.UserId == Id).FirstOrDefault();
            if (user != null)
            {
                user.FirstName = userInfo.FirstName;
                user.LastName = userInfo.LastName;
                user.Employee_ID = userInfo.Employee_ID;
            }
            dbContext.Users.Add(user);
            dbContext.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            isSave = dbContext.SaveChanges() > 0;

            return isSave;
        }

        bool IUserRepository.DeleteUser(int userId)
        {
            var entity = dbContext.Users.FirstOrDefault(u => u.UserId == userId);
            if (entity == null)
            {
                return false;
            }
            else
            {
                dbContext.Users.Remove(entity);
                dbContext.SaveChanges();
                return true;
            }
        }

        List<User> IUserRepository.GetAllUser(string sortbycolumn = "", string serachBy = "")
        {
            List<User> users = new List<User>();

            if (string.IsNullOrEmpty(sortbycolumn))
            {
                sortbycolumn = "UserId";
            }
            if (!string.IsNullOrEmpty(serachBy))
            {
                users = dbContext.Users.Where(x => x.FirstName.ToLower().Contains(serachBy.ToLower())).ToList();
            }
            else
            {
                var propertyInfo = typeof(User).GetProperty(sortbycolumn);
                users = dbContext.Users.OrderBy(x => propertyInfo.GetValue(x, null)).ToList();
            }
            return users;
        }

        List<User> IUserRepository.SortUsers(string sortOrder, string sortBy)
        {
            List<User> users = new List<User>();
            var propertyInfo = typeof(User).GetProperty(sortBy);

            if (sortOrder == "ASC")
            {
                users = dbContext.Users.OrderBy(x => propertyInfo.GetValue(x, null)).ToList();
            }
            else
            {
                users = dbContext.Users.OrderByDescending(x => propertyInfo.GetValue(x, null)).ToList();
            }
            return users;

        }

        User IUserRepository.GetById(int userId)
        {
            List<User> users = new List<User>();

            var userInfo = dbContext.Users.Where(x => x.UserId == userId).FirstOrDefault();
            return userInfo;
        }
    }
}
