using eShop.BLL.Automapper;
using eShop.BLL.Interfaces;
using eShop.BLL.Services;
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
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddDataContext(configuration);
    }
}