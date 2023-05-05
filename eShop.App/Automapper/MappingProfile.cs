using AutoMapper;
using eShop.App.Models.Token;
using eShop.App.ViewModels.Order;
using eShop.App.ViewModels.Product;
using eShop.App.ViewModels.User;
using eShop.BLL.Models;
using eShop.BLL.Models.Token;

namespace eShop.App.Automapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<LoginBllModel, LoginViewModel>().ReverseMap();

        CreateMap<TokenDetailsAppModel, TokenDetailsModel>().ReverseMap();
        CreateMap<TokenAppModel, TokenModel>().ReverseMap();

        CreateMap<UserModel, UserViewModel>().ReverseMap();
        CreateMap<UserModel, UserDetailsViewModel>().ReverseMap();
        CreateMap<UserModel, RegisterViewModel>().ReverseMap();
        CreateMap<UserModel, UserUpdateViewModel>().ReverseMap();

        CreateMap<ProductModel, ProductViewModel>().ReverseMap();
        CreateMap<ProductModel, ProductCreateViewModel>().ReverseMap();
        CreateMap<ProductModel, ProductUpdateViewModel>().ReverseMap();

        CreateMap<OrderModel, OrderViewModel>().ReverseMap();
        CreateMap<OrderModel, OrderCreateViewModel>().ReverseMap();
        CreateMap<OrderModel, OrderUpdateViewModel>().ReverseMap();
    }
}
