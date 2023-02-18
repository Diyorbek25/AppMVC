using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AppMVC.Domain.Entities;

namespace AppMVC.Infrastructure.EntityTypeConfigurations;

public sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(user => user.Id);

        builder.Property(user => user.UserName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(user => user.UserName)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(user => user.Salt)
            .HasMaxLength(255);

        builder.Property(user => user.UserRole)
            .IsRequired();

        builder.HasData(GenerateUsers());
    }

    public List<User> GenerateUsers()
    {
        return new List<User>
        {
            new User
            {
                Id = 1,
                UserName = "admin",
                PasswordHash = "admin1",
                Salt = Guid.NewGuid().ToString(),
                UserRole = Domain.Enums.Role.Admin
            },
            new User
            {
                Id = 2,
                UserName = "user",
                PasswordHash = "user1",
                Salt = Guid.NewGuid().ToString(),
                UserRole = Domain.Enums.Role.User
            }
        };
    }
}
