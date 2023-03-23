using AutoMapper;
using eShop.BLL.Models;
using eShop.DAL.Entities;
using eShop.DAL.Models;

namespace eShop.BLL.Automapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<LoginDalModel, LoginBllModel>().ReverseMap();
        CreateMap<UserEntity, UserModel>().ReverseMap();
        CreateMap<ProductEntity, ProductModel>().ReverseMap();
        CreateMap<OrderEntity, OrderModel>().ReverseMap();
    }
}
