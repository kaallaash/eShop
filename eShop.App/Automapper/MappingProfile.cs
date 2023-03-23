using AutoMapper;
using eShop.App.ViewModels;
using eShop.BLL.Models;

namespace eShop.App.Automapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<LoginBllModel, LoginViewModel>().ReverseMap();
        CreateMap<UserModel, RegisterViewModel>().ReverseMap();
        //CreateMap<ProductModel, ProductViewModel>().ReverseMap();
    }
}
