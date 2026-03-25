using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accounting_Settle_Up_System.Models.Entities;

[Table("payments")]
public class Payment : BaseEntity
{
    [Column("from_user_id")]
    public Guid FromUserId { get; set; }

    [Column("to_user_id")]
    public Guid ToUserId { get; set; }

    [Column("group_id")]
    public Guid GroupId { get; set; }

    [Column("amount")]
    public decimal Amount { get; set; }

    [Column("date")]
    public DateTime Date { get; set; } = DateTime.UtcNow;

    [Column("description")]
    [StringLength(250)]
    public string Description { get; set; } = string.Empty;

    [Column("is_settled")]
    public bool IsSettled { get; set; }

    [ForeignKey("FromUserId")]
    public virtual User? FromUser { get; set; }

    [ForeignKey("ToUserId")]
    public virtual User? ToUser { get; set; }

    [ForeignKey("GroupId")]
    public virtual Group? Group { get; set; }
}
