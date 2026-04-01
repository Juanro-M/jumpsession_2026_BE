using Accounting_Settle_Up_System.Models;
using Accounting_Settle_Up_System.Models.DTOs;

namespace Accounting_Settle_Up_System.Interfaces;

public interface IAuthService
{
    Task<AuthResult> RegisterAsync(RegisterDto registerDto);
    Task<AuthResult> LoginAsync(LoginDto loginDto, CancellationToken cancellationToken);
}