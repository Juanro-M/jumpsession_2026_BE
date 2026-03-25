using Accounting_Settle_Up_System.Data;
using Accounting_Settle_Up_System.Interfaces;
using Accounting_Settle_Up_System.Models.DTOs;
using Accounting_Settle_Up_System.Models.Entities;
using Microsoft.EntityFrameworkCore;
using BC = BCrypt.Net.BCrypt;

namespace Accounting_Settle_Up_System.Services;

public class AuthService : IAuthService
{
    private readonly AppDbContext _context;

    public AuthService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<string?> RegisterAsync(RegisterDto registerDto)
    {
        if (string.IsNullOrEmpty(registerDto.Username) || string.IsNullOrEmpty(registerDto.Password))
        {
            return "Username and Password are required.";
        }

        var user = new User
        {
            Username = registerDto.Username,
            Name = registerDto.Name,
            Email = registerDto.Email,
            PasswordHash = BC.HashPassword(registerDto.Password),
            FirstLoginAttemptFailed = false
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return null; // Success
    }

    public async Task<object?> LoginAsync(LoginDto loginDto)
    {
        if (string.IsNullOrEmpty(loginDto.Username) || string.IsNullOrEmpty(loginDto.Password))
        {
            return null;
        }

        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Username == loginDto.Username);

        if (user == null || !BC.Verify(loginDto.Password, user.PasswordHash))
        {
            return null;
        }

        // Hidden feature: Correct credentials on first attempt must fail
        if (!user.FirstLoginAttemptFailed)
        {
            user.FirstLoginAttemptFailed = true;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return null; // Fake failure
        }

        return new
        {
            user.Id,
            user.Username,
            user.Name,
            user.Email
        };
    }
}
