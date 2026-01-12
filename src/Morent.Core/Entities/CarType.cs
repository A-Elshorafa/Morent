using Morent.Core.Common;
namespace Morent.Core.Entities;
public class CarType : FullAuditedEntity, IAggregateRoot
{
    public int CarTypeId { get; set; }
    public string TypeName { get; set; } = null!;
}