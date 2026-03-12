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

        }

    }
}