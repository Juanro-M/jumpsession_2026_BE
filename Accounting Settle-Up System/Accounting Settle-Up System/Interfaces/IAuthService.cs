using Accounting_Settle_Up_System.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Accounting_Settle_Up_System.Interfaces;

public interface IAuthService
{
    Task<string?> RegisterAsync(RegisterDto registerDto);
    Task<object?> LoginAsync(LoginDto loginDto);
}
