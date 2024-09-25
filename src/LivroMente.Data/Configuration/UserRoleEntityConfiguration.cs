using LivroMente.Domain.Models.IdentityEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LivroMente.Data.Configuration
{
    public class UserRoleEntityConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(u => new {u.UserId,u.RoleId});

            builder.HasOne(u => u.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(u => u.RoleId)
                    .IsRequired();

            builder.HasOne(u => u.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(u => u.UserId)
                    .IsRequired();
        }
    }
}