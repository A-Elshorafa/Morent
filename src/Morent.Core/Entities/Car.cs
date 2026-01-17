using System.ComponentModel.DataAnnotations;
using Morent.Core.Common;

namespace Morent.Core.Entities;
public class Car : FullAuditedEntity, IAggregateRoot
{
  [Key]
    public int CarId { get; set; }

    public string ModelName { get; set; } = null!;
    public decimal RentalPrice { get; set; }

    public string LicensePlate { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int Year { get; set; }
    public string Color { get; set; } = null!;
    public int NoOfPassengers { get; set; }
    public int FuelCapacity { get; set; }
    public bool IsAutomatic { get; set; }
    public bool IsAvailable { get; set; }
    public bool IsPopular { get; set; }
    public string PhotoUrl { get; set; } = null!;

    // Relations
    public int CarTypeId { get; set; }
    public virtual CarType CarType { get; set; } = null!;
    public int OwnerId { get; set; }
    public virtual User Owner { get; set; } = null!;
    public int CompanyId { get; set; }
    public virtual CarCompany Company { get; set; } = null!;
    
    public ICollection<CarReview> Reviews { get; private set; } = new List<CarReview>();
}
