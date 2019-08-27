using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CTS.HackFSE.DataAccess.Entity
{
    [Table("Tasks")]
    public partial class Task
    {
        [Key]
        public int Task_ID { get; set; }
        public Nullable<int> Parent_ID { get; set; }
        public Nullable<int> ProjectId { get; set; }
        public string TaskName { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<int> PriorityValue { get; set; }
        public string Status { get; set; }
        public virtual ParentTask ParentTask { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public virtual Project Project { get; set; }        
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public virtual ICollection<User> Users { get; set; }
    }
}
