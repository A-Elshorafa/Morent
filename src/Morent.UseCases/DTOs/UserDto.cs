namespace Morent.UseCases.DTOs;

public class CreateUserDto
{
  public string? FullName { get; set; } = null!;
  public string? Email { get; set; } = null!;
  public string? PhoneNumber { get; set; } = null!;
  public string? NationalID { get; set; } = null!;
  public DateTime? DateOfBirth { get; set; }
  public string? Address { get; set; } = null!;
  public string? DrivingLicenseNumber { get; set; } = null!;
  public string? JobRole { get; set; } = null!;
  public string? PhotoUrl { get; set; } = null!;

  public CreateUserDto(
    string? fullName = null,
    string? email = null,
    string? phoneNumber = null,
    string? nationalID = null,
    DateTime? dateOfBirth = null,
    string? address = null,
    string? drivingLicenseNumber = null,
    string? jobRole = null,
    string? photoUrl = null)
  {
    FullName = fullName;
    Email = email;
    PhoneNumber = phoneNumber;
    NationalID = nationalID;
    DateOfBirth = dateOfBirth;
    Address = address;
    DrivingLicenseNumber = drivingLicenseNumber;
    JobRole = jobRole;
    PhotoUrl = photoUrl;
  }
}

// Update DTO inherits from Create DTO and adds UserId
public class UpdateUserDto : CreateUserDto
{
  public int UserId { get; set; }
}

// Response DTO for returning user data
public class UserDto
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

  public UserDto(
    int? userId = null,
    string? fullName = null,
    string? email = null,
    string? phoneNumber = null,
    string? nationalID = null,
    DateTime? dateOfBirth = null,
    string? address = null,
    string? drivingLicenseNumber = null,
    string? jobRole = null,
    string? photoUrl = null
  ) {
    UserId = userId?? 0;
    FullName = fullName ?? string.Empty;
    Email = email ?? string.Empty;
    PhoneNumber = phoneNumber ?? string.Empty;
    NationalID = nationalID ?? string.Empty;
    DateOfBirth = dateOfBirth ?? DateTime.MinValue;
    Address = address ?? string.Empty;
    DrivingLicenseNumber = drivingLicenseNumber ?? string.Empty;
    JobRole = jobRole ?? string.Empty;
    PhotoUrl = photoUrl ?? string.Empty;
  }
}

// Optional lightweight DTO for listing users
public class UserListDto
{
  public int UserId { get; set; }
  public string FullName { get; set; } = null!;
  public string Email { get; set; } = null!;
}
