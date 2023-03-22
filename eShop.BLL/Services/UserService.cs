using AutoMapper;
using eShop.BLL.Interfaces;
using eShop.BLL.Models;
using eShop.DAL.Entities;
using eShop.DAL.Interfaces.Repositories;

namespace eShop.BLL.Services;

public class UserService : GenericServiceAsync<UserModel, UserEntity>, IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper) : base(userRepository, mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
}