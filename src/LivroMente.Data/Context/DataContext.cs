using LivroMente.Data.Configuration;
using LivroMente.Domain.Models.BookModel;
using LivroMente.Domain.Models.CategoryBookModel;
using LivroMente.Domain.Models.IdentityEntities;
using LivroMente.Domain.Models.OrderDetailsModel;
using LivroMente.Domain.Models.OrderModel;
using LivroMente.Domain.Models.PaymentModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LivroMente.Data.Context
{
    public class DataContext : IdentityDbContext<User, Role, string,
            IdentityUserClaim<string>, UserRole, IdentityUserLogin<string>,
            IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public DataContext(DbContextOptions<DataContext> options):base(options){}

        public DbSet<Book> Book {get;set;}
        public DbSet<CategoryBook> CategoryBook {get;set;}
        public DbSet<Payment> Payment {get;set;}
        public DbSet<Order> Order {get;set;}
        public DbSet<OrderDetails> OrderDetails {get;set;}
        public DbSet<User> User {get;set;}
        public DbSet<Role> Role {get;set;}
        public DbSet<UserRole> UserRole {get;set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        }
    }
}