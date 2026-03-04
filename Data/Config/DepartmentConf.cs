using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AppStudent.Data.Config
{
    public class DepartmentConf : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {

            builder.ToTable("Departments");
            builder.HasKey(n => n.Id);

            builder.Property(n => n.Id).UseIdentityColumn();

            builder.Property(n => n.NameDepartment).IsRequired();
            builder.Property(n => n.Description);


        }
    }
}


