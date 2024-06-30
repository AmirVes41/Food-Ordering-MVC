using firstProj.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Manage.Internal;
using Microsoft.EntityFrameworkCore;
namespace firstProject.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "غذای اصلی", DisplayOrder = 1 },
                new Category { Id = 2, Name = "پیش غذا", DisplayOrder = 2 },
                new Category { Id = 3, Name = "مخلفات", DisplayOrder = 3 },
                new Category { Id = 4, Name = "نوشیدنی", DisplayOrder = 4 }
                );

            modelBuilder.Entity<Company>().HasData(
             new Company
             {
                 Id = 1,
                 Name = "ICT",
                 Unit = "SeSad",
                 Code = "1111111111",
                 PhoneNumber = "09120000000"
             },
             new Company
             {
                 Id = 2,
                 Name = "HR",
                 Unit = "SeSad",
                 Code = "1111111111",
                 PhoneNumber = "09120000000"
             }
             );
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "آش",
                    Description = "لوبیا سبزیجات رشته دوغ",
                    Price = 26000,
                    Count = 35,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 2,
                    Name = "نوشابه",
                    Description = "  ",
                    Price = 15000,
                    Count = 25,
                    CategoryId = 4
                },
                new Product
                {
                    Id = 3,
                    Name = "سوپ رشته",
                    Description = "رشته فرنگی رب هویج نخود فرنگی ادویه",
                    Price = 30000,
                    Count = 15,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 4,
                    Name = "سالاد سزار",
                    Description = "کاهو سس و سزار رنده شده",
                    Price = 150000,
                    Count = 30,
                    CategoryId = 3
                },
                new Product
                {
                    Id = 5,
                    Name = "دوغ",
                    Description = "  ",
                    Price = 15000,
                    Count = 25,
                    CategoryId = 4
                }
                );
        }
    }
}
