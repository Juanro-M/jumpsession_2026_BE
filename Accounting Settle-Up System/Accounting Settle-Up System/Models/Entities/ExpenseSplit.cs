using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accounting_Settle_Up_System.Models.Entities;

[Table("expense_splits")]
public class ExpenseSplit : BaseEntity
{
    [Column("expense_id")]
    public Guid ExpenseId { get; set; }

    [Column("user_id")]
    public Guid UserId { get; set; }

    [Column("split_amount")]
    public decimal SplitAmount { get; set; }

    [Column("split_percentage")]
    public decimal SplitPercentage { get; set; }

    [ForeignKey("ExpenseId")]
    public virtual Expense? Expense { get; set; }

    [ForeignKey("UserId")]
    public virtual User? User { get; set; }
}
