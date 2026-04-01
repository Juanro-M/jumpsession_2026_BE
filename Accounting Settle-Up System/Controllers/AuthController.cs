using Accounting_Settle_Up_System.Interfaces;
using Accounting_Settle_Up_System.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Accounting_Settle_Up_System.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        var result = await authService.RegisterAsync(registerDto);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto, CancellationToken cancellationToken)
    {
        var result = await authService.LoginAsync(loginDto,cancellationToken);
        return result.Success ? Ok(result) : Unauthorized(result);
    }
}
