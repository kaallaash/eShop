using eShop.BLL.Models;
using eShop.Core.Interfaces;

namespace eShop.BLL.Interfaces;

public interface IUserService : IGenericServiceAsync<UserModel>
{
    Task<UserModel> GetByLoginAsync(LoginBllModel login, CancellationToken cancellationToken);
    Task<UserModel> GetByUsernameAsync(string username, CancellationToken cancellationToken);
}
