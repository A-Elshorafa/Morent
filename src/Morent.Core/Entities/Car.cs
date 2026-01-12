using Morent.Core.Common;

namespace Morent.Core.Entities;
public class Car : FullAuditedEntity, IAggregateRoot
{
    public int CarId { get; set; }

    public string ModelName { get; set; } = null!;
    public decimal RentalPrice { get; set; }

    public string LicensePlate { get; set; } = null!;
    public int Year { get; set; }
    public string Color { get; set; } = null!;
    public int NoOfPassengers { get; set; }
    public string FuelCapacity { get; set; } = null!;
    public bool IsAutomatic { get; set; }
    public bool IsAvailable { get; set; }

    // Relations
    public int CarTypeId { get; set; }
    public virtual CarType CarType { get; set; } = null!;
    public int OwnerId { get; set; }
    public virtual User Owner { get; set; } = null!;
    public int CompanyId { get; set; }
    public virtual Company Company { get; set; } = null!;
}