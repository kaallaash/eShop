using AutoMapper;
using eShop.BLL.Interfaces;
using eShop.BLL.Models;
using eShop.DAL.Entities;
using eShop.DAL.Interfaces.Repositories;
using eShop.DAL.Models;

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

    public async Task<UserModel?> GetByLoginAsync(LoginBllModel login, CancellationToken cancellationToken)
    {
        var logindalModel = _mapper.Map<LoginDalModel>(login);
        var userEntity = await _userRepository.GetByLoginAsync(logindalModel, cancellationToken);

        return _mapper.Map<UserModel>(userEntity);
    }

    public async Task<UserModel?> GetByUsernameAsync(string username, CancellationToken cancellationToken)
    {
        var userEntity = await _userRepository.GetByUsernameAsync(username, cancellationToken);

        return _mapper.Map<UserModel>(userEntity);
    }
}