using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CTS.HackFSE.Business.DTO;
using CTS.HackFSE.Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CTS.HackFSE.Service.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserInfoBO _userBO;
        public UserController(IUserInfoBO userBO)
        {
            _userBO = userBO;
        }

        [HttpGet]
        [Route("Get")]
        public List<UserInfoDTO> Get()
        {
            return _userBO.GetAllUser("", "");
        }

        [HttpGet]
        [Route("GetByName")]
        public List<UserInfoDTO> Get(string name, string sortbycolumn = "")
        {
            return _userBO.GetAllUser(sortbycolumn, name);
        }

        [HttpGet]
        [Route("SortUsers")]
        public List<UserInfoDTO> SortUsers(string sortOrder, string sortBy)
        {
            return _userBO.SortUsers(sortOrder, sortBy);
        }

        [HttpPost]
        [Route("InsertUser")]
        public bool Post([FromBody] UserInfoDTO userInfo)
        {
            return _userBO.CreateUser(userInfo);
        }

        [HttpPost]
        [Route("UpdateUser")]
        public bool Put(int Id, [FromBody] UserInfoDTO userInfo)
        {
            if (Id != userInfo.UserID)
            {
                throw new ArgumentException();
            }
            return _userBO.UpdateUser(Id, userInfo);
        }

        [HttpPost]
        [Route("DeleteUser")]
        public bool Delete(int Id)
        {
            var user = _userBO.GetById(Id);

            if (user == null)
            {
                throw new ArgumentException();
            }

            return _userBO.DeleteUser(Id);
        }

    }
}