namespace Morent.UseCases.DTOs;

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
}
