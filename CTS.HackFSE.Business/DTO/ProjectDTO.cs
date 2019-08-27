using System;
using System.Collections.Generic;
using System.Text;

namespace CTS.HackFSE.Business.DTO
{
    public partial class ProjectDTO
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int UserId { get; set; }
        public string ManagerName { get; set; }
        public int? Priority { get; set; }
        public UserInfoDTO UserInfo { get; set; }
    }
}
