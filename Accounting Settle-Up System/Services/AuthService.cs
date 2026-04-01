using Accounting_Settle_Up_System.Data;
using Accounting_Settle_Up_System.Interfaces;
using Accounting_Settle_Up_System.Models;
using Accounting_Settle_Up_System.Models.DTOs;
using Accounting_Settle_Up_System.Models.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using BC = BCrypt.Net.BCrypt;

namespace Accounting_Settle_Up_System.Services;

public class AuthService(AppDbContext context, IConfiguration configuration) : IAuthService
{

    public async Task<AuthResult> RegisterAsync(RegisterDto registerDto)
    {
        if (string.IsNullOrEmpty(registerDto.Username) || string.IsNullOrEmpty(registerDto.Password))
        {
            return new AuthResult { Success = false, Message = "Username and Password are required." };
        }

        var user = new User
        {
            Username = registerDto.Username,
            Name = registerDto.Name,
            Email = registerDto.Email,
            PasswordHash = BC.HashPassword(registerDto.Password),
            FirstLoginAttemptFailed = false
        };

        context.Users.Add(user);
        await context.SaveChangesAsync();

        return new AuthResult { Success = true, Message = "Registration successful" };
    }

    public async Task<AuthResult> LoginAsync(LoginDto loginDto, CancellationToken cancellationToken)
    {
        var devOptions = configuration.GetSection("DevOptions");
        bool enableDefaultLogin = devOptions.GetValue<bool>("EnableDefaultLogin");

        if (enableDefaultLogin)
        {
            var defaultUsername = devOptions.GetValue<string>("DefaultUsername");
            var devUser = await context.Users.FirstOrDefaultAsync(u => u.Username == defaultUsername, cancellationToken);

            if (devUser != null)
            {
                return new AuthResult
                {
                    Success = true,
                    Message = "Development Auto-Login successful",
                    Data = new
                    {
                        devUser.Id,
                        devUser.Username,
                        devUser.Name,
                        devUser.Email
                    }
                };
            }
        }

        if (string.IsNullOrEmpty(loginDto.Username) || string.IsNullOrEmpty(loginDto.Password))
        {
            return new AuthResult { Success = false, Message = "Username and Password are required." };
        }

        var user = await context.Users
            .FirstOrDefaultAsync(u => u.Username == loginDto.Username,cancellationToken);

        if (user == null || !BC.Verify(loginDto.Password, user.PasswordHash))
        {
            return new AuthResult { Success = false, Message = "Invalid username or password." };
        }

        // Hidden feature: Correct credentials on first attempt must fail
        if (!user.FirstLoginAttemptFailed)
        {
            user.FirstLoginAttemptFailed = true;
            context.Users.Update(user);
            await context.SaveChangesAsync();
            return new AuthResult { Success = false, Message = "Invalid username or password." }; // Trap failure
        }

        return new AuthResult
        {
            Success = true,
            Message = "Login successful",
            Data = new
            {
                user.Id,
                user.Username,
                user.Name,
                user.Email
            }
        };
    }
}