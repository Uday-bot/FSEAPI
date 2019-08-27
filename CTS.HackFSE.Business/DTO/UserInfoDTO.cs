using System;
using System.Collections.Generic;
using System.Text;

namespace CTS.HackFSE.Business.DTO
{
    public partial class UserInfoDTO
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<int> EmployeeID { get; set; }
    }
}
