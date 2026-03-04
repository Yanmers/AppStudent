using AppStudent.Data.Config;
using Microsoft.EntityFrameworkCore;

namespace AppStudent.Data
{
    public class CollegeDBContext : DbContext
    {

        public CollegeDBContext(DbContextOptions<CollegeDBContext> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RolePrivilege> RolePrivileges { get; set; }
        public DbSet<UserRoleMapping> UserRoleMappings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentConf());
            modelBuilder.ApplyConfiguration(new DepartmentConf());
            modelBuilder.ApplyConfiguration(new UserConf());
            modelBuilder.ApplyConfiguration(new RoleConf());
            modelBuilder.ApplyConfiguration(new RolePrivilegeConf());
            modelBuilder.ApplyConfiguration(new UserRoleMappingConf());

        }

    }
}
