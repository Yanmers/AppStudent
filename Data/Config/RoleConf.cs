using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AppStudent.Data.Config
{
    public class RoleConf : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {

            builder.ToTable("Roles");
            builder.HasKey(n => n.Id);

            builder.Property(n => n.Id).UseIdentityColumn();

            builder.Property(n => n.RoleName).IsRequired();
            builder.Property(n => n.Description);
            builder.Property(n => n.IsActive).IsRequired();
            builder.Property(n => n.IsDelete).IsRequired();
            builder.Property(n => n.CreateDate).IsRequired();

        }
    }
}
