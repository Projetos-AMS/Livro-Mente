using LivroMente.Domain.Models.BookModel;
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

            builder.Property<Guid>("Id")
                   .ValueGeneratedOnAdd();

            builder.HasOne<Order>()
            .WithMany()
            .IsRequired()
            .HasForeignKey(_ => _.OrderId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_OrderDetails_Order");

            // builder.HasMany<Book>()
            // .WithOne()
            // .IsRequired()
            // .HasForeignKey("BookId")
            // .OnDelete(DeleteBehavior.ClientSetNull)
            // .HasConstraintName("FK_OrderDetails_Book");
            

            builder.Property(od => od.Amount)
                   .IsRequired();

            builder.Property(od => od.ValueUni)
                   .IsRequired();
        }
    }
}