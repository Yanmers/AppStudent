using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AppStudent.Data.Config
{
    public class UserConf : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.ToTable("Users");
            builder.HasKey(n => n.Id);

            builder.Property(n => n.Id).UseIdentityColumn();

            builder.Property(n => n.UserName).IsRequired();
            builder.Property(n => n.Password).IsRequired();
            builder.Property(n => n.PasswordSalt).IsRequired();
            builder.Property(n => n.UserTypeId).IsRequired();
            builder.Property(n => n.IsActive).IsRequired();
            builder.Property(n => n.IsDelete).IsRequired();
            builder.Property(n => n.CreateDate).IsRequired();


        }
    }
}