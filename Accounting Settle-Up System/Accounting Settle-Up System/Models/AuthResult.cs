namespace Accounting_Settle_Up_System.Models;

public class AuthResult
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public object? Data { get; set; }
}
