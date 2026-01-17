using System.ComponentModel.DataAnnotations;
using Morent.Core.Common;
namespace Morent.Core.Entities;
public class UserPreference : FullAuditedEntity
{
  [Key]
    public int UserPreferencesId { get; set; }
    public int CarId { get; set; }
    public virtual Car Car { get; set; } = null!;
    public int UserId { get; set; }
    public virtual User User { get; set; } = null!;
}
