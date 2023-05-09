using eShop.BLL.Interfaces;
using eShop.BLL.Models.Token;

namespace eShop.App.Middlewares;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IConfiguration _configuration;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public JwtMiddleware(
        IConfiguration config, 
        RequestDelegate next,
        IServiceScopeFactory serviceScopeFactory)
    {
        _configuration = config;
        _next = next;
        _serviceScopeFactory = serviceScopeFactory;
    }

    public async Task Invoke(HttpContext context)
    {
        using (var scope = _serviceScopeFactory.CreateScope())
        {
            var accessToken = context.Request.Cookies["accessToken"];
            var refreshToken = context.Request.Cookies["refreshToken"];

            if (!string.IsNullOrEmpty(accessToken) && !string.IsNullOrEmpty(refreshToken))
            {
                var tokenService = scope.ServiceProvider.GetRequiredService<ITokenService>();
                var isAccessTokenExpired = await tokenService.IsAccessTokenExpired(accessToken, default);

                if (isAccessTokenExpired)
                {
                    var tokenModel = new TokenModel()
                    {
                        AccessToken = accessToken,
                        RefreshToken = refreshToken
                    };

                    var tokenDetails = await tokenService.RefreshTokenAsync(tokenModel, default);

                    if (tokenDetails?.AccessToken is not null && tokenDetails?.RefreshToken is not null)
                    {
                        _ = int.TryParse(_configuration["CookieLifeTime:JwtTokenLifeTimeInDays"], out var tokenValidityInDays);

                        if (tokenValidityInDays == 0)
                        {
                            tokenValidityInDays = 1;
                        }

                        await SetCookie(context.Response.Cookies, nameof(tokenDetails.AccessToken),
                            tokenDetails.AccessToken, DateTime.UtcNow.AddDays(tokenValidityInDays));
                        await SetCookie(context.Response.Cookies, nameof(tokenDetails.RefreshToken),
                            tokenDetails.RefreshToken, DateTime.UtcNow.AddMinutes(tokenValidityInDays));
                        await SetCookie(context.Response.Cookies, nameof(tokenDetails.RefreshToken),
                            tokenDetails.RefreshToken, DateTime.UtcNow.AddMinutes(tokenValidityInDays));
                    }
                }
            }
        }

        await _next(context);
    }

    private static Task SetCookie(IResponseCookies cookies, string key, string value, DateTimeOffset expires)
    {
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Expires = expires
        };

        cookies.Append(key, value, cookieOptions);

        return Task.CompletedTask;
    }
}