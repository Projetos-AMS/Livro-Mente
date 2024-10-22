using LivroMente.Domain.Models.BookModel;
using LivroMente.Domain.Models.CategoryBookModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LivroMente.Data.Configuration
{
    public class BookEntityConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Book");

            builder.Property<Guid>("Id")
                    .ValueGeneratedOnAdd();

            builder.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(b => b.Author)
                .IsRequired()
                .HasMaxLength(60);

            builder.Property(b => b.Synopsis)
                .HasMaxLength(300);

            builder.Property(b => b.PublishingCompany)
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(b => b.Isbn)
            .HasMaxLength(20);

            builder.Property(b => b.Value)
                .IsRequired();

            builder.Property(b => b.Language)
                .IsRequired()
                .HasMaxLength(2);

            builder.Property(b => b.Classification)
                .IsRequired();

            builder.HasOne<CategoryBook>()
                  .WithMany()
                  .IsRequired()
                  .HasForeignKey(b => b.CategoryId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_Book_CategoryBook");

           




        }
    }
}