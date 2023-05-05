using eShop.BLL.Models;
using eShop.BLL.Models.Token;
using System.Runtime.CompilerServices;

namespace eShop.BLL.Interfaces;

public interface ITokenService
{
    Task<TokenDetailsModel?> Login(LoginBllModel login, CancellationToken cancellationToken);
    Task<TokenDetailsModel?> RefreshToken(TokenModel tokenModel, CancellationToken cancellationToken);
}
