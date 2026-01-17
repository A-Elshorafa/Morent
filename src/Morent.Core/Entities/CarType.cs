using System.ComponentModel.DataAnnotations;
using Morent.Core.Common;
namespace Morent.Core.Entities;
public class CarType : FullAuditedEntity, IAggregateRoot
{
  [Key]
    public int CarTypeId { get; set; }
    public string TypeName { get; set; } = null!;
}
