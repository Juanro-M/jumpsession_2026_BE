using Accounting_Settle_Up_System.Models.DTOs;

namespace Accounting_Settle_Up_System.Interfaces;

public interface IUserService
{
    Task <UserDto> GetUserAsync(string email,CancellationToken cancellationToken);
}
