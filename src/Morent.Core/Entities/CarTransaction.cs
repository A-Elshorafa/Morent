using Morent.Core.Common;
namespace Morent.Core.Entities;
public class CarTransaction : FullAuditedEntity, IAggregateRoot
{
    public int CarTransactionId { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }
    public decimal RentalPrice { get; set; }

    public int CarId { get; set; }
    public virtual Car Car { get; set; } = null!;
    public int RenterId { get; set; }
    public virtual User Renter { get; set; } = null!;
    public int PickupLocationId { get; set; }
    public virtual Location PickupLocation { get; set; } = null!;
    public int DropOfLocationId { get; set; }
    public virtual Location DropOfLocation { get; set; } = null!;
}