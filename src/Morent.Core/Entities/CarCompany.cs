using Morent.Core.Common;
namespace Morent.Core.Entities;
public class Company : FullAuditedEntity, IAggregateRoot
{
    public int CompanyId { get; set; }
    public string CompanyName { get; set; } = null!;
}