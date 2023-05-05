using System.IdentityModel.Tokens.Jwt;
using eShop.BLL.Interfaces;

namespace eShop.App.Middlewares;

public class RefreshTokenMiddleware
{
    private readonly RequestDelegate _next;

    public RefreshTokenMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    //public async Task InvokeAsync(HttpContext context, IUserService userService)
    //{
    //    string accessToken = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

    //    if (accessToken != null)
    //    {
    //        var principal = JwtHelper.ValidateToken(accessToken, context);

    //        if (principal == null || !principal.Identity.IsAuthenticated)
    //        {
    //            var refreshToken = context.Request.Cookies["refreshToken"];

    //            if (refreshToken != null)
    //            {
    //                var newAccessToken = refreshTokenService.RefreshAccessToken(refreshToken);

    //                if (newAccessToken != null)
    //                {
    //                    context.Response.Headers.Add("Authorization", "Bearer " + newAccessToken);
    //                }
    //            }
    //        }
    //    }

    //    await _next(context);
    //}
}