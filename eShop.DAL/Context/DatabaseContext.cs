using Microsoft.EntityFrameworkCore;
using eShop.DAL.Entities;

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
}