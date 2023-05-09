using eShop.BLL.Interfaces;
using eShop.BLL.Models;
using eShop.BLL.Models.Token;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace eShop.BLL.Services;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;
    private readonly IUserService _userService;

    public TokenService(IConfiguration config, IUserService userService)
    {
        _configuration = config;
        _userService = userService;
    }

    public async Task<TokenDetailsModel?> LoginAsync(LoginBllModel login, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(login.Username) ||
            string.IsNullOrEmpty(login.Password))
        {
            throw new ArgumentException("Invalid Username or Password");
        }

        var user = await _userService.GetByLoginAsync(login, cancellationToken);

        if (user?.Username is null || user?.Role is null)
        {
            throw new ArgumentException("A user with such username or password was not found");
        }

        var claims = new[] {
            new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, user.Role.ToString()),
        };

        var accessToken = CreateToken(claims);
        var newRefreshToken = GenerateRefreshToken();
        _ = int.TryParse(_configuration["JWT:RefreshTokenValidityInDays"], out var refreshTokenValidityInDays);

        user.RefreshToken = newRefreshToken;
        user.RefreshTokenExpiryTime = DateTime.Now.AddDays(refreshTokenValidityInDays);

        var updatedUser = await _userService.UpdateAsync(user, cancellationToken);

        return new TokenDetailsModel()
        {
            AccessToken = new JwtSecurityTokenHandler().WriteToken(accessToken),
            RefreshToken = newRefreshToken,
            RefreshTokenExpiryTime = user.RefreshTokenExpiryTime
        };
    }

    public async Task<TokenDetailsModel?> RefreshTokenAsync(TokenModel tokenModel, CancellationToken cancellationToken)
    {
        var accessToken = tokenModel.AccessToken;
        var refreshToken = tokenModel.RefreshToken;

        var principal = GetPrincipalFromExpiredToken(accessToken);

        if (principal?.Identity?.Name is null)
        {
            return null;
            //return await Task.FromException<TokenDetailsModel>(
            //    new ArgumentException("Invalid access token or refresh token"));
        }

        var userName = principal.Identity.Name;

        var user = await _userService.GetByUsernameAsync(userName, cancellationToken);

        if (user is null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
        {
            return null;
            //return await Task.FromException<TokenDetailsModel>(
            //    new ArgumentException("Invalid access token or refresh token"));
        }

        var newAccessToken = CreateToken(principal.Claims.ToList());
        var newRefreshToken = GenerateRefreshToken();

        _ = int.TryParse(_configuration["JWT:RefreshTokenValidityInDays"], out var refreshTokenValidityInDays);

        user.RefreshToken = newRefreshToken;
        user.RefreshTokenExpiryTime = DateTime.Now.AddDays(refreshTokenValidityInDays);

        await _userService.UpdateAsync(user, cancellationToken);

        return new TokenDetailsModel()
        {
            AccessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
            RefreshToken = newRefreshToken,
            RefreshTokenExpiryTime = user.RefreshTokenExpiryTime
        };
    }

    public async Task<bool> IsAccessTokenExpired(string token, CancellationToken cancellationToken)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var validationParameters = new TokenValidationParameters
        {
            //ValidateIssuerSigningKey = true,
            //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"])),
            //ValidateIssuer = false,
            //ValidateAudience = false,
            //ClockSkew = TimeSpan.Zero
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"])),
            ValidateLifetime = false
        };

        try
        {
            var claimsPrincipal = tokenHandler.ValidateToken(token, validationParameters, out var validatedToken);

            if (validatedToken != null)
            {
                return DateTime.UtcNow > validatedToken.ValidTo; ;
            }
        }
        catch (Exception)
        {
            return false;
            // token validation failed
        }

        return true;
    }

    private ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"])),
            ValidateLifetime = false
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);
        if (securityToken is not JwtSecurityToken jwtSecurityToken
            || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            throw new SecurityTokenException("Invalid token");

        return principal;

    }

    private SecurityToken CreateToken(IEnumerable<Claim> authClaims)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        _ = int.TryParse(_configuration["JWT:TokenValidityInMinutes"], out var tokenValidityInMinutes);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Issuer = _configuration["JWT:Issuer"],
            Audience = _configuration["JWT:Audience"],
            Subject = new ClaimsIdentity(authClaims),
            Expires = DateTime.Now.AddMinutes(tokenValidityInMinutes),
            SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return token;
    }

    private static string GenerateRefreshToken()
    {
        var randomNumber = new byte[64];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }

    //private async static Task SetCookie(string name, )
    //{
    //    var cookieOptions = new CookieOptions
    //    {
    //        HttpOnly = true,
    //        Expires = DateTime.UtcNow.AddMinutes(30), // время жизни куки - 30 минут
    //    };
    //    Response.Cookies.Append("mycookie", "cookievalue", cookieOptions);
    //}
}