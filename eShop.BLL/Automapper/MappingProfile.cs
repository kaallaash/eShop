using AutoMapper;
using eShop.BLL.Models;
using eShop.DAL.Entities;

namespace eShop.BLL.Automapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserEntity, UserModel>().ReverseMap();
        CreateMap<ProductEntity, ProductModel>().ReverseMap();
        CreateMap<OrderEntity, OrderModel>().ReverseMap();
    }
}
