using eShop.Core.Interfaces;
using eShop.DAL.Entities;
using eShop.DAL.Models;

namespace eShop.DAL.Interfaces.Repositories;

public interface IUserRepository : IGenericRepositoryAsync<UserEntity>
{
    Task<UserEntity?> GetByLoginAsync(LoginDalModel login, CancellationToken cancellationToken);
    Task<UserEntity?> GetByUsernameAsync(string username, CancellationToken cancellationToken);
}