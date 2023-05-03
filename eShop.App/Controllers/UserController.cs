using System.Runtime.CompilerServices;
using AutoMapper;
using eShop.App.ViewModels.User;
using eShop.BLL.Interfaces;
using eShop.BLL.Models;
using eShop.Core.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAll() => 
        View(await _userService.GetAllAsync(default));

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

        return RedirectToAction("Index", "Product");
    }

    public IActionResult Register() => View(new RegisterViewModel());

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel registerVievModel, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid) return View(registerVievModel);

        var userModel = _mapper.Map<UserModel>(registerVievModel);
        userModel.Role = Role.User;

        var user = await _userService.CreateAsync(userModel, cancellationToken);

        if (user is null)
        {
            TempData["Error"] = "This email address is already in use";
            return View(registerVievModel);
        }

        return View("RegisterCompleted");
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        await _userService.DeleteAsync(id, cancellationToken);

        return View("DeleteCompleted");
    }
}