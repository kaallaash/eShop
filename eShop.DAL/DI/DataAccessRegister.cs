using eShop.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eShop.DAL.DI;

public static class DataAccessRegister
{
    public static void AddDataContext(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        //services.AddScoped<IDrawingRepository<DrawingEntity>, DrawingRepository>();
        //services.AddScoped<IDrawingRepository<DrawingEntity>, DrawingRepository>();
        //services.AddScoped<IDrawingRepository<DrawingEntity>, DrawingRepository>();

        services.AddDbContext<DatabaseContext>(op =>
        {
            op.UseSqlServer(
                configuration.GetConnectionString("eShopDb"));
        });
    }
}