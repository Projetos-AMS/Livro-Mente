using LivroMente.Domain.Models.OrderDetailsModel;
using LivroMente.Domain.Models.OrderModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LivroMente.Data.Configuration
{
    public class OrderDetailsEntityConfiguration : IEntityTypeConfiguration<OrderDetails>
    {
        public void Configure(EntityTypeBuilder<OrderDetails> builder)
        {
            builder.ToTable("OrderDetails");

            builder.Property<string>("Id")
                   .ValueGeneratedOnAdd();

            builder.HasOne<Order>()
            .WithMany(o => o.OrderDetails)
            .IsRequired()
            .HasForeignKey(b => b.OrderId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_OrderDetails_Order");

            builder.HasOne(b => b.Book)
            .WithMany()
            .IsRequired()
            .HasForeignKey(b => b.BookId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_OrderDetails_Book");
            

            builder.Property(od => od.Amount)
                   .IsRequired();

            builder.Property(od => od.ValueUni)
                   .IsRequired();
        }
    }
}