using Morent.Core.Common;

namespace Morent.Core.Entities;
public class User : FullAuditedEntity, IAggregateRoot
{
    public int UserId { get; set; }

    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string NationalID { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public string Address { get; set; } = null!;
    public string DrivingLicenseNumber { get; set; } = null!;
    public string JobRole { get; set; } = null!;
    public string PhotoUrl { get; set; } = null!;
}