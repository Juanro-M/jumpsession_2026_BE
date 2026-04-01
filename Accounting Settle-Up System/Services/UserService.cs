using Accounting_Settle_Up_System.Data;
using Accounting_Settle_Up_System.Interfaces;
using Accounting_Settle_Up_System.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Accounting_Settle_Up_System.Services;

public class UserService(AppDbContext context) : IUserService
{
     public async Task<UserDto> GetUserAsync(string email, CancellationToken cancellationToken)
    {
        var targetUser = await context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email == email, cancellationToken) 
                        ?? throw new Exception("User not found via email");

        return new UserDto
        {
         Id = targetUser.Id,
         Username = targetUser.Username,
         Name = targetUser.Name,
         Email = targetUser.Email
        };
    }
}
