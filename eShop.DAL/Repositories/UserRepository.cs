using eShop.DAL.Context;
using eShop.DAL.Entities;
using eShop.DAL.Interfaces.Repositories;

namespace eShop.DAL.Repositories;

public class UserRepository : GenericRepositoryAsync<UserEntity>, IUserRepository
{
    public UserRepository(DatabaseContext context) : base(context) { }
}
