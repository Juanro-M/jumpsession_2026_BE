using Microsoft.AspNetCore.Mvc;

namespace Accounting_Settle_Up_System.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    [HttpGet("ping")]
    public IActionResult Ping()
    {
        return Ok(new { message = "pong", timestamp = System.DateTime.UtcNow });
    }

    [HttpGet("user")]
    public IActionResult GetTestUser()
    {
        return Ok(new
        {
            id = 1,
            username = "test_user",
            email = "test@example.com",
            firstName = "John",
            lastName = "Doe"
        });
    }

    [HttpGet("groups")]
    public IActionResult GetTestGroups()
    {
        return Ok(new[]
        {
            new { id = 1, name = "Trip to Paris", createdBy = 1 },
            new { id = 2, name = "Shared Apartment", createdBy = 1 }
        });
    }

    [HttpGet("expenses")]
    public IActionResult GetTestExpenses()
    {
        return Ok(new[]
        {
            new { id = 101, groupId = 1, description = "Dinner", amount = 45.50, paidBy = 1, createdAt = System.DateTime.UtcNow.AddHours(-5) },
            new { id = 102, groupId = 1, description = "Louvre Tickets", amount = 34.00, paidBy = 1, createdAt = System.DateTime.UtcNow.AddHours(-2) },
            new { id = 201, groupId = 2, description = "Electricity Bill", amount = 120.00, paidBy = 1, createdAt = System.DateTime.UtcNow.AddDays(-1) }
        });
    }
}
