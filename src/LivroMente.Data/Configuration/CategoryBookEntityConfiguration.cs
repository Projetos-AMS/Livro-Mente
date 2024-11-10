using LivroMente.Domain.Models.CategoryBookModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LivroMente.Data.Configuration
{
    public class CategoryBookEntityConfiguration : IEntityTypeConfiguration<CategoryBook>
    {
        public void Configure(EntityTypeBuilder<CategoryBook> builder)
        {
            builder.ToTable("CategoryBook");

            builder.Property<string>("Id")
                   .ValueGeneratedOnAdd();
                   
            builder.Property(c => c.Description)
                   .IsRequired()
                   .HasMaxLength(80);
        }
    }
}