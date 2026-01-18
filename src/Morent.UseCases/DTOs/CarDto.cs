namespace Morent.UseCases.DTOs;

public class CreateCarDto
{
  public required string ModelName { get; set; }
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
  public int OwnerId { get; set; }
  public int CompanyId { get; set; }
}

public class UpdateCarDto : CreateCarDto
{
  public int CarId { get; set; }
}

public class CarInfoCardDto
{
  public required string ModelName { get; set; }
  public decimal RentalPrice { get; set; }
  public required string TypeName { get; set; }
  public required bool IsPreferred { get; set; }
  public required string PhotoURL { get; set; }
  public int FuelCapacity { get; set; }
  public bool IsAutomatic { get; set; }
  public int NoOfPassengers { get; set; }

  public CarInfoCardDto(string modelName, int fuelCapacity, int noOfPassengers, bool isAutomatic,
    decimal rentalPrice, string typeName, bool isPreffered, string photoURL)
  {
    ModelName = modelName;
    FuelCapacity = fuelCapacity;
    NoOfPassengers = noOfPassengers;
    IsAutomatic = isAutomatic;
    RentalPrice = rentalPrice;
    TypeName = typeName;
    IsPreferred = isPreffered;
    PhotoURL = photoURL;
  }
}
