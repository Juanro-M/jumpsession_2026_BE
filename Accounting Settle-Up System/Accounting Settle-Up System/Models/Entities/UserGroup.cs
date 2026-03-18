using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accounting_Settle_Up_System.Models.Entities;

[Table("user_groups")]
public class UserGroup : BaseEntity
{
    [Column("user_id")]
    public Guid UserId { get; set; }

    [Column("group_id")]
    public Guid GroupId { get; set; }

    [ForeignKey("UserId")]
    public virtual User? User { get; set; }

    [ForeignKey("GroupId")]
    public virtual Group? Group { get; set; }
}
