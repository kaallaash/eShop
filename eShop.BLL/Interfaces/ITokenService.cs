using eShop.BLL.Models;
using eShop.BLL.Models.Token;

namespace eShop.BLL.Interfaces;

public interface ITokenService
{
    Task<TokenDetailsModel?> LoginAsync(LoginBllModel login, CancellationToken cancellationToken);
    Task<TokenDetailsModel?> RefreshTokenAsync(TokenModel tokenModel, CancellationToken cancellationToken);
    Task<bool> IsAccessTokenExpired(string token, CancellationToken cancellationToken);
}
