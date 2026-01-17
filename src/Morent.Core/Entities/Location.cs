using System.ComponentModel.DataAnnotations;
using Morent.Core.Common;
namespace Morent.Core.Entities;
public class Location : FullAuditedEntity, IAggregateRoot
{
  [Key]
    public int LocationId { get; set; }
    public string LocationName { get; set; } = null!;
}
