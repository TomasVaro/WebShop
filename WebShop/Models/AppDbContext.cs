using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<ProductModel> Product { get; set; }
        public DbSet<ProductOrderModel> ProductOrder { get; set; }
        public DbSet<OrderModel> Order { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProductOrderModel>().HasKey(pl => new { pl.ProductId, pl.OrderId });
            modelBuilder.Entity<ProductOrderModel>()
                .HasOne(po => po.Order)
                .WithMany(p => p.Products)
                .HasForeignKey(po => po.OrderId);

            modelBuilder.Entity<ProductOrderModel>()
                .HasOne(po => po.Product)
                .WithMany(p => p.Orders)
                .HasForeignKey(po => po.ProductId);

            modelBuilder.Entity<ProductModel>().HasData(
                new ProductModel { ProductId = 1, ProductName = "Super Mario Galaxy", Price = 150, ImageName = "SuperMarioGalaxy.png", Description = "Mario defies gravity."});
            modelBuilder.Entity<ProductModel>().HasData(
                new ProductModel { ProductId = 2, ProductName = "Dark Souls Remastered", Price = 150, ImageName = "DarkSoulsRemastered.png", Description = "Prepare to die." });
            modelBuilder.Entity<ProductModel>().HasData(
                new ProductModel { ProductId = 3, ProductName = "Pokémon Brilliant Diamond", Price = 300, ImageName = "PokémonBrilliantDiamond.png", Description = "Remake of Pokémon Diamond." });
            modelBuilder.Entity<ProductModel>().HasData(
                new ProductModel { ProductId = 4, ProductName = "The Elder Scrolls V: Skyrim", Price = 300, ImageName = "Skyrim.png", Description = "An open world, Action RPG from Bethesda." });


            string adminRoleId = Guid.NewGuid().ToString();
            string userRoleId = Guid.NewGuid().ToString();
            string userId = Guid.NewGuid().ToString();
            // Create Admin-role
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = adminRoleId,
                Name = "Admin",
                NormalizedName = "ADMIN"
            });
            // Creates User-role
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = userRoleId,
                Name = "User",
                NormalizedName = "USER"
            });
            // Create Admin user
            PasswordHasher<ApplicationUser> hasher = new PasswordHasher<ApplicationUser>();
            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = userId,
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                PasswordHash = hasher.HashPassword(null, "asdfgh"),
                PhoneNumber = "070-123 45 67",
                FirstName = "Admin",
                LastName = "Adminsson",
                Street = "Storgatan 3",
                ZipCode = "123 45",
                City = "Göteborg"
            });
            // Assign Admin user an Admin role
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = adminRoleId,
                UserId = userId
            });
        }
    }
}
