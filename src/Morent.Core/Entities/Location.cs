using Morent.Core.Common;
namespace Morent.Core.Entities;
public class Location : FullAuditedEntity, IAggregateRoot
{
    public int LocationId { get; set; }
    public string LocationName { get; set; } = null!;
}