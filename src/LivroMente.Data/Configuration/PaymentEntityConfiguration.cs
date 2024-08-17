using LivroMente.Domain.Models.PaymentModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LivroMente.Data.Configuration
{
    public class PaymentEntityConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payment");

            builder.Property<Guid>("Id")
                   .ValueGeneratedOnAdd();

            builder.Property(p => p.Description)
                   .IsRequired()
                   .HasMaxLength(20);

        }
    }
}