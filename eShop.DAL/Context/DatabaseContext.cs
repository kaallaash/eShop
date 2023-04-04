using Microsoft.EntityFrameworkCore;
using eShop.DAL.Entities;
using eShop.DAL.Models;

namespace eShop.DAL.Context;

public class DatabaseContext : DbContext
{
    public DbSet<UserEntity> Users { get; set; } = null!;
    public DbSet<ProductEntity> Products { get; set; } = null!;
    public DbSet<OrderEntity> Orders { get; set; } = null!;

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
        if (base.Database.IsRelational())
        {
            base.Database.Migrate();
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserEntity>().HasData(
            new UserEntity
            {
                Id = -1,
                Username = "admin",
                Password = "admin",
                Email = "adminEmail@eShop.com",
                Role = Role.Admin,
                DateCreated = DateTimeOffset.Now,
                DateUpdated = DateTimeOffset.Now,
            }
        );
        modelBuilder.Entity<ProductEntity>().HasData(
            new ProductEntity {
                Id = -1,
                Name = "Drill", 
                Price = 49.99m,
                Description = "Electric drill =)",
                Count = 10,
                DateCreated = DateTimeOffset.Now,
                DateUpdated = DateTimeOffset.Now
            },
            new ProductEntity
            {
                Id = -2,
                Name = "Hammer",
                Price = 19.99m,
                Description = "The hammer like my grandfather's",
                Count = 25,
                DateCreated = DateTimeOffset.Now,
                DateUpdated = DateTimeOffset.Now
            },
            new ProductEntity
            {
                Id = -3,
                Name = "Nails",
                Price = 5.99m,
                Description = "Not aluminum",
                Count = 1000,
                DateCreated = DateTimeOffset.Now,
                DateUpdated = DateTimeOffset.Now
            }
        );
    }
}