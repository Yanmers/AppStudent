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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new StudentConf());
            //modelBuilder.ApplyConfiguration(new DepartmentConf());

            modelBuilder.Entity<Student>().HasData(new List<Student>()
            {
                new Student {
                    Id = 1,
                    Name = "YanielMercedes",
                    Address="SantoDomingo",
                    Email="mercedesyaniel@mail.com",
                    DBO = new DateTime(2026-01-01)

                },
                new Student {
                    Id = 2,
                    Name = "Admin",
                    Address="SantoDomingo",
                    Email="mercedesyaniel@mail.com",
                    DBO = new DateTime(2026-01-01)

                }
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(n => n.Name).IsRequired().HasMaxLength(150);
                entity.Property(n => n.Address).IsRequired().HasMaxLength(500);
                entity.Property(n => n.Email).IsRequired().HasMaxLength(200);
            });

        }

    }
}
