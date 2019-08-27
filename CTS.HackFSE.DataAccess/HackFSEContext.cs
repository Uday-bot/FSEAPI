using CTS.HackFSE.DataAccess.Entity;
using Microsoft.EntityFrameworkCore;
namespace CTS.HackFSE.DataAccess
{
    public class HackFSEContext : DbContext
    {
        public HackFSEContext(DbContextOptions<HackFSEContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>(entity =>
            {
                entity.Property(e => e.ProjectName).IsRequired();
            });
        }
        public virtual DbSet<ParentTask> ParentTasks { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
