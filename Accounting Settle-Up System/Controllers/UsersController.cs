using Accounting_Settle_Up_System.Interfaces;
using Accounting_Settle_Up_System.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Accounting_Settle_Up_System.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController(IUserService userService) : ControllerBase
{
    [HttpGet]
    public async Task<UserDto> GetUserByEmail([FromQuery] string email, CancellationToken cancellationToken)
    {
        return await userService.GetUserAsync(email, cancellationToken);
    }
}