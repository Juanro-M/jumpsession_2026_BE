using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accounting_Settle_Up_System.Models.Entities;

[Table("expenses")]
public class Expense : BaseEntity
{
    [Column("description")]
    [StringLength(250)]
    public string Description { get; set; } = string.Empty;

    [Column("total_amount")]
    public decimal TotalAmount { get; set; }

    [Column("date")]
    public DateTime Date { get; set; } = DateTime.UtcNow;

    [Column("group_id")]
    public Guid GroupId { get; set; }

    [Column("paid_by_id")]
    public Guid PaidById { get; set; }

    [ForeignKey("GroupId")]
    public virtual Group? Group { get; set; }

    [ForeignKey("PaidById")]
    public virtual User? PaidBy { get; set; }

    // Navigation properties
    public virtual ICollection<ExpenseSplit>? Splits { get; set; }
}
