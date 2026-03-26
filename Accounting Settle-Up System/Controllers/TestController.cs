using Microsoft.AspNetCore.Mvc;

namespace Accounting_Settle_Up_System.Controllers;

/// <summary>
/// Smoke-test endpoints — no DB required.
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class TestController : ControllerBase
{
    /// <summary>Health check.</summary>
    /// <response code="200">Returns pong + server timestamp.</response>
    [HttpGet("ping")]
    public IActionResult Ping() =>
        Ok(new { message = "pong", timestamp = DateTime.UtcNow });

    /// <summary>Returns a hardcoded test user.</summary>
    [HttpGet("user")]
    public IActionResult GetTestUser() =>
        Ok(new { id = 1, username = "test_user", email = "test@example.com", firstName = "John", lastName = "Doe" });

    /// <summary>Returns a list of test groups.</summary>
    [HttpGet("groups")]
    public IActionResult GetTestGroups() =>
        Ok(new[]
        {
            new { id = 1, name = "Trip to Paris",     createdBy = 1 },
            new { id = 2, name = "Shared Apartment",  createdBy = 1 }
        });

    /// <summary>Returns test expenses across groups.</summary>
    [HttpGet("expenses")]
    public IActionResult GetTestExpenses() =>
        Ok(new[]
        {
            new { id = 101, groupId = 1, description = "Dinner",           amount = 45.50,  paidBy = 1, createdAt = DateTime.UtcNow.AddHours(-5) },
            new { id = 102, groupId = 1, description = "Louvre Tickets",   amount = 34.00,  paidBy = 1, createdAt = DateTime.UtcNow.AddHours(-2) },
            new { id = 201, groupId = 2, description = "Electricity Bill", amount = 120.00, paidBy = 1, createdAt = DateTime.UtcNow.AddDays(-1)  }
        });
}