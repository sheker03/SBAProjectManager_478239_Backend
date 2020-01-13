using ProjectManager.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Data
{

    public class ProjectDBContext : DbContext
    {
        public ProjectDBContext() : base("name=ProjectDBConnect")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<ProjectDBContext>(null);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Model.Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
