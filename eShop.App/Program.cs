using eShop.App.Automapper;
using eShop.BLL.DI;
using eShop.App.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddBll(builder.Configuration);
builder.Services.AddAuthentication(builder.Configuration);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseMiddleware<RedirectOnUnauthorizedMiddleware>();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseMiddleware<JwtMiddleware>();
app.UseMiddleware<AuthorizationHeaderMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}/{id?}");

app.Run();