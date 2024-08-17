using LivroMente.Data.Configuration;
using LivroMente.Domain.Models.AdressModel;
using LivroMente.Domain.Models.BookModel;
using LivroMente.Domain.Models.CategoryBookModel;
using LivroMente.Domain.Models.IdentityEntities;
using LivroMente.Domain.Models.OrderDetailsModel;
using LivroMente.Domain.Models.OrderModel;
using LivroMente.Domain.Models.PaymentModel;
using Microsoft.EntityFrameworkCore;

namespace LivroMente.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options):base(options){}

        public DbSet<Book> Book {get;set;}
        public DbSet<Adress> Adress {get;set;}
        public DbSet<CategoryBook> CategoryBook {get;set;}
        public DbSet<Payment> Payment {get;set;}
        public DbSet<Order> Order {get;set;}
        public DbSet<OrderDetails> OrderDetails {get;set;}

        public DbSet<User> User {get;set;}
        public DbSet<Role> Role {get;set;}
        public DbSet<UserRole> UserRole {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryBookEntityConfiguration());
            modelBuilder.ApplyConfiguration(new AdressEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentEntityConfiguration());
            modelBuilder.ApplyConfiguration(new OrderEntityConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailsEntityConfiguration());
            modelBuilder.ApplyConfiguration(new BookEntityConfiguration());

            modelBuilder.Entity<UserRole>(up =>{
                up.HasKey(u => new {u.UserId,u.RoleId});

                up.HasOne(u => u.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(u => u.RoleId)
                .IsRequired();

                up.HasOne(u => u.User)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(u => u.UserId)
                .IsRequired();
            });
        }

    }
}