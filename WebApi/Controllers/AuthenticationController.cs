using Domain.Abstract.Service;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Model;

namespace WebApi.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly IJwtService _jWtManager;

    public AuthenticationController(IJwtService jWtManager)
    {
        _jWtManager = jWtManager;
    }

    [AllowAnonymous]
    [HttpPost]
    public IActionResult Authenticate(LoginModel model)
    {
        var token = _jWtManager.Authenticate(new User
        {
            Login = model.Login,
            Password = model.Password
        });

        return token == null ? Unauthorized() : Ok(token);
    }
}