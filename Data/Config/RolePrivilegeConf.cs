using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AppStudent.Data.Config
{
    public class RolePrivilegeConf : IEntityTypeConfiguration<RolePrivilege>
    {
        public void Configure(EntityTypeBuilder<RolePrivilege> builder)
        {

            builder.ToTable("RolePrivileges");
            builder.HasKey(n => n.Id);

            builder.Property(n => n.Id).UseIdentityColumn();

            builder.Property(n => n.RolePrivilegeName).IsRequired();
            builder.Property(n => n.Description);
            builder.Property(n => n.RoleId).IsRequired();
            builder.Property(n => n.IsActive).IsRequired();
            builder.Property(n => n.IsDelete).IsRequired();
            builder.Property(n => n.CreateDate).IsRequired();

            builder.HasOne(n => n.Role)
                .WithMany(n => n.RolePrivileges)
                .HasForeignKey(n => n.RoleId)
                .HasConstraintName("FK_RolePrivileges_Roles");

        }
    }
}

