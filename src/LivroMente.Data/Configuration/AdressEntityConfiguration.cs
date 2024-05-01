using LivroMente.Domain.Models.AdressModel;
using LivroMente.Domain.Models.IdentityEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LivroMente.Data.Configuration
{
    public class AdressEntityConfiguration : IEntityTypeConfiguration<Adress>
    {
        public void Configure(EntityTypeBuilder<Adress> builder)
        {
            builder.ToTable("Adress");

            builder.Property<Guid>("Id")
                   .ValueGeneratedOnAdd();

            builder.Property(a => a.CEP)
                   .IsRequired()
                   .HasMaxLength(8);

            builder.Property(a => a.City)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(a => a.Neighborhood)
                   .IsRequired()
                   .HasMaxLength(30);

            builder.Property(a => a.Street)
                   .IsRequired()
                   .HasMaxLength(30);

            builder.Property(a => a.Number)
                    .IsRequired()
                    .HasMaxLength(10);

            builder.Property(a => a.State)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.Property(a => a.Complement)
                    .IsRequired()
                    .HasMaxLength(30);

            builder.HasOne<User>()
            .WithMany()
            .IsRequired()
            .HasForeignKey(_ => _.UserId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Adress_User");
        }
    }
}