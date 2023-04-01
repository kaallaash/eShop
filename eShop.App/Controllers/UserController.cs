using AutoMapper;
using eShop.App.ViewModels.User;
using eShop.BLL.Interfaces;
using eShop.BLL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace eShop.App.Controllers;

public class UserController : Controller
{

    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UserController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    public IActionResult Login() => View(new LoginViewModel());

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel loginViewModel, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid) return View(loginViewModel);

        var user = await _userService.GetByLoginAsync(_mapper.Map<LoginBllModel>(loginViewModel), cancellationToken);

        if (user is null)
        {
            TempData["Error"] = "Wrong credentials. Please, try again!";
            return View(loginViewModel);
        }

        //if (user.Username is not null)
        //{
        //    var identity = new ClaimsIdentity(new[] {
        //        new Claim(ClaimTypes.Name, user.Username),
        //        //new Claim(ClaimTypes.Role, "role")
        //    }, "MyAuthType");

        //    HttpContext.User = new ClaimsPrincipal(identity);
        //}

        return RedirectToAction("Index", "Product");
    }

    public IActionResult Register() => View(new RegisterViewModel());

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel registerVievModel, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid) return View(registerVievModel);

        var user = await _userService.CreateAsync(_mapper.Map<UserModel>(registerVievModel), cancellationToken);

        if (user is null)
        {
            TempData["Error"] = "This email address is already in use";
            return View(registerVievModel);
        }

        return View("RegisterCompleted");
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        await _userService.DeleteAsync(id, cancellationToken);

        return View("DeleteCompleted");
    }
}