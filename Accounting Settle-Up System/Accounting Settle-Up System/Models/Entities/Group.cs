using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accounting_Settle_Up_System.Models.Entities;

[Table("groups")]
public class Group : BaseEntity
{
    [Column("name")]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Column("description")]
    [StringLength(500)]
    public string Description { get; set; } = string.Empty;

    // Navigation properties
    public virtual ICollection<UserGroup>? UserGroups { get; set; }
    public virtual ICollection<Expense>? Expenses { get; set; }
}
