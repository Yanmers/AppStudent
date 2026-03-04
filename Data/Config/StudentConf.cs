using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppStudent.Data.Config
{
    public class StudentConf : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {

            builder.ToTable("Students");
            builder.HasKey(n => n.Id);

            builder.Property(n => n.Id).UseIdentityColumn();

            builder.Property(n => n.StudentName).IsRequired();
            builder.Property(n => n.Email).IsRequired();
            builder.Property(n => n.Address).IsRequired();
            builder.Property(n => n.DBO).IsRequired();

            //builder.HasOne(n => n.Department)
            //   .WithMany(n => n.Students)
            //   .HasForeignKey(n => n.DeparmentId)
            //   .HasConstraintName("FK_Students_Department");




        }



        //modelBuilder.Entity<Student>().HasData(new List<Student>()
        //{
        //    new Student {
        //        Id = 1,
        //        Name = "YanielMercedes",
        //        Address="SantoDomingo",
        //        Email="mercedesyaniel@mail.com",
        //        DBO = new DateTime(2026-01-01)

        //    },
        //    new Student {
        //        Id = 2,
        //        Name = "Admin",
        //        Address="SantoDomingo",
        //        Email="mercedesyaniel@mail.com",
        //        DBO = new DateTime(2026-01-01)

        //    }
        //});

        //modelBuilder.Entity<Student>(entity =>
        //{
        //    entity.Property(n => n.Name).IsRequired().HasMaxLength(150);
        //    entity.Property(n => n.Address).IsRequired().HasMaxLength(500);
        //    entity.Property(n => n.Email).IsRequired().HasMaxLength(200);
        //});
    }
}