using System.ComponentModel.DataAnnotations;
using Morent.Core.Common;
namespace Morent.Core.Entities;
public class CarCompany : FullAuditedEntity, IAggregateRoot
{
    [Key]
    public int CompanyId { get; set; }
    public string CompanyName { get; set; } = null!;
}
