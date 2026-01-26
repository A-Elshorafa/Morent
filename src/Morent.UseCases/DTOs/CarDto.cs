using Morent.Core.Entities;

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
  public int CarId { get; set; }
  public string ModelName { get; set; }
  public decimal RentalPrice { get; set; }
  public string TypeName { get; set; }
  public bool IsPreferred { get; set; }
  public string PhotoURL { get; set; }
  public int FuelCapacity { get; set; }
  public bool IsAutomatic { get; set; }
  public int NoOfPassengers { get; set; }

  public CarInfoCardDto(int carId, string modelName, int fuelCapacity, int noOfPassengers, bool isAutomatic,
    decimal rentalPrice, string typeName, bool isPreffered, string photoURL)
  {
    CarId = carId;
    ModelName = modelName;
    FuelCapacity = fuelCapacity;
    NoOfPassengers = noOfPassengers;
    IsAutomatic = isAutomatic;
    RentalPrice = rentalPrice;
    TypeName = typeName;
    IsPreferred = isPreffered;
    PhotoURL = photoURL;
  }
  
  public CarInfoCardDto(Car carData, bool isPreferred, string typeName)
  {
    ModelName = carData.ModelName;
    FuelCapacity = carData.FuelCapacity;
    NoOfPassengers = carData.NoOfPassengers;
    IsAutomatic = carData.IsAutomatic;
    RentalPrice = carData.RentalPrice;
    PhotoURL = carData.PhotoUrl;
    IsPreferred = isPreferred;
    TypeName = typeName;
  }
}
