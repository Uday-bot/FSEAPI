using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CTS.HackFSE.DataAccess.Entity
{
    [Table("Projects")]
    public partial class Project
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public int UserId { get; set; }
        public string ManagerName { get; set; }
        public Nullable<int> Priority { get; set; }
        public virtual User UserInfo { get; set; }
    }
}
