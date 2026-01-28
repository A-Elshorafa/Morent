using Morent.Core.DTOs;

namespace Morent.Web.Features.Car.Update;

public class UpdateCarRequest : UpdateCarDto
{
  public const string Route = "{Id:int}";
  public int Id { get; set; }
  public string Name { get; set; } = "";
}
