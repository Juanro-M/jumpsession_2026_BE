using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accounting_Settle_Up_System.Models.Entities;

[Table("users")]
public class User : BaseEntity
{
    
    [Column("username")]
    [StringLength(100)]
    public string Username { get; set; } = string.Empty;

    [Column("email")]
    [StringLength(150)]
    public string Email { get; set; } = string.Empty;

    [Column("password_hash")]
    public string PasswordHash { get; set; } = string.Empty;

    [Column("first_login_attempt_failed")]
    public bool FirstLoginAttemptFailed { get; set; } = false;
    [Column("name")]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    public virtual ICollection<UserGroup>? UserGroups { get; set; }
    public virtual ICollection<Expense>? ExpensesPaid { get; set; }
    public virtual ICollection<ExpenseSplit>? ExpenseSplits { get; set; }
}
