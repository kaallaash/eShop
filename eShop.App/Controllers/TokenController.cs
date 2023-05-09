using AutoMapper;
using eShop.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using eShop.BLL.Models;
using eShop.App.ViewModels.User;
using eShop.BLL.Models.Token;
using eShop.App.Models.Token;

namespace eShop.App.Controllers;

[Route("api/token")]
[ApiController]
public class TokenController : Controller
{
    private readonly ITokenService _tokenService;
    private readonly IMapper _mapper;

    public TokenController(ITokenService tokenService, IMapper mapper)
    {
        _tokenService = tokenService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel loginModel, CancellationToken cancellationToken)
    {
        var token = await _tokenService.LoginAsync(_mapper.Map<LoginBllModel>(loginModel), cancellationToken);

        if (token is null)
        {
            return BadRequest();
        }

        return Ok(token);
    }

    [HttpPost]
    [Route("refresh-token")]
    public async Task<IActionResult> RefreshToken(TokenAppModel tokenModel, CancellationToken cancellationToken)
    {
        var token = await _tokenService.RefreshTokenAsync(_mapper.Map<TokenModel>(tokenModel), cancellationToken);

        if (token is null)
        {
            return BadRequest();
        }

        return Ok(token);
    }
}