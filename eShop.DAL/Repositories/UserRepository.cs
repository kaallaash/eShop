using eShop.DAL.Context;
using eShop.DAL.Entities;
using eShop.DAL.Interfaces.Repositories;
using eShop.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace eShop.DAL.Repositories;

public class UserRepository : GenericRepositoryAsync<UserEntity>, IUserRepository
{
    private readonly DatabaseContext _context;
    public UserRepository(DatabaseContext context) : base(context)
    {
        _context = context;
    }

    public async Task<UserEntity?> GetByLoginAsync(LoginDalModel login, CancellationToken cancellationToken)
    {
        return  await _context.Users.FirstOrDefaultAsync(
            u => u.Username == login.Username && u.Password == login.Password, cancellationToken);
    }
}
