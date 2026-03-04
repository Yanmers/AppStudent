using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AppStudent.Data.Config
{
    public class UserTypeConf : IEntityTypeConfiguration<UserType>
    {
        public void Configure(EntityTypeBuilder<UserType> builder)
        {

            builder.ToTable("UserTypes");
            builder.HasKey(n => n.Id);

            builder.Property(n => n.Id).UseIdentityColumn();

            builder.Property(n => n.Name).IsRequired().HasMaxLength(250);
            builder.Property(n => n.Description).HasMaxLength(1500);

            builder.HasData(new List<UserType>()
            {
                new UserType {
                    Id = 1,
                    Name = "Student",
                    Description = "for Students",

                },
                new UserType {
                    Id = 2,
                    Name = "Faculty",
                    Description = "for Faculty",

                },
                new UserType {
                    Id = 3,
                    Name = "Supporting Staff",
                    Description = "for Supporting Staf",

                },
                new UserType {
                    Id = 4,
                    Name = "Parents",
                    Description = "for Parents",

                }
            });


        }
    }
}