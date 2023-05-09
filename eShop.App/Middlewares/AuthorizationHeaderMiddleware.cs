namespace eShop.App.Middlewares;

public class AuthorizationHeaderMiddleware
{
    private readonly RequestDelegate _next;

    public AuthorizationHeaderMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var accessToken = context.Request.Cookies["accessToken"];
        
        if (!string.IsNullOrEmpty(accessToken))
        {
            context.Request.Headers.Add("Authorization", $"Bearer {accessToken}");
        }
        
        await _next(context);
    }
}