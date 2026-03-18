using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accounting_Settle_Up_System.Models.Entities;

[Table("users")]
public class User : BaseEntity
{
    [Column("name")]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Column("email")]
    [StringLength(150)]
    public string Email { get; set; } = string.Empty;

    public virtual ICollection<UserGroup>? UserGroups { get; set; }
    public virtual ICollection<Expense>? ExpensesPaid { get; set; }
    public virtual ICollection<ExpenseSplit>? ExpenseSplits { get; set; }
}
