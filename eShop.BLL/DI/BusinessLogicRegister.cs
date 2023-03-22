using eShop.BLL.Automapper;
using eShop.DAL.DI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eShop.BLL.DI;

public static class BusinessLogicRegister
{
    public static void AddBll(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddAutoMapper(typeof(MappingProfile));
        //services.AddScoped<IDrawingService<Drawing, int>, DrawingService>();
        //services.AddScoped<IDrawingService<Drawing, int>, DrawingService>();
        //services.AddScoped<IDrawingService<Drawing, int>, DrawingService>();
        services.AddDataContext(configuration);
    }
}