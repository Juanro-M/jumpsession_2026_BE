using Accounting_Settle_Up_System.Interfaces;
using Accounting_Settle_Up_System.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Accounting_Settle_Up_System.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        var error = await _authService.RegisterAsync(registerDto);
        if (error != null)
        {
            return BadRequest(error);
        }

        return Ok(new { message = "Registration successful" });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        var user = await _authService.LoginAsync(loginDto);
        if (user == null)
        {
            return Unauthorized("Invalid username or password.");
        }

        return Ok(new
        {
            message = "Login successful",
            user
        });
    }
}
