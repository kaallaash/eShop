using eShop.Core.Interfaces;
using eShop.DAL.Entities;

namespace eShop.DAL.Interfaces.Repositories;

public interface IUserRepository : IGenericRepositoryAsync<UserEntity>
{
}