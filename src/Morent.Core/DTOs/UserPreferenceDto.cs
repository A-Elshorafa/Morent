using Morent.Core.DTOs;
using Morent.Core.Entities;

namespace Morent.Core.DTOs;

public class CreateUserPreferenceDto
{
  public int CarId { get; set; }
  public int UserId { get; set; }
}

// Used when updating an existing preference
public class UpdateUserPreferenceDto : CreateUserPreferenceDto
{
  public int UserPreferencesId { get; set; }
}

// Used when returning preference data
public class UserPreferenceDto
{
  public int UserPreferencesId { get; set; }
  public CarInfoCardDto? CarInfo { get; set; }

  public UserPreferenceDto(int userPreferencesId, Car carData, bool isPreferred, string carType)
  {
    UserPreferencesId = userPreferencesId;
    CarInfo = new CarInfoCardDto(carData, isPreferred, carType);
  }
}
