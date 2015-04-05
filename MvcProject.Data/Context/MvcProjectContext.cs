using MvcProject.Data.Mapping;
using MvcProject.Core.Domain.Entity;
using System.Data.Entity;

namespace MvcProject.Data.Context
{
    public class MvcProjectContext : DbContext
    {
        public MvcProjectContext()
            : base("DefaultConnection")
        {
            Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<Role> Role { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new RoleMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
