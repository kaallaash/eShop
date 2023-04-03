namespace eShop.App.Middlewares;

public class RedirectOnUnauthorizedMiddleware
{
    private readonly RequestDelegate _next;

    public RedirectOnUnauthorizedMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        await _next(context);

        if (context.Response.StatusCode == 401)
        {
            context.Response.Redirect("/user/login");
        }
    }
}

