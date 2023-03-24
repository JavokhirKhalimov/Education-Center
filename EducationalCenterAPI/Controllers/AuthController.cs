using EducationalCenterAPI.Models.PostModels;
using EducationalCenterAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EducationalCenterAPI.Controllers;

[ApiController,
    Route("api/[controller]/[action]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _auth;
    public AuthController(IAuthService auth)
    {
        _auth = auth;
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterModel register)
        => Ok(await _auth.RegisterAsync(register));

    [HttpPost]
    public async Task<IActionResult> Login(LoginModel login)
        => Ok(await _auth.LoginAsync(login));
}
