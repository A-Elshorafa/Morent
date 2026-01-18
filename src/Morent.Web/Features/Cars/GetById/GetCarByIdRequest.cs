namespace Morent.Web.Features.Car.GetById;

public class GetCarByIdRequest
{
  public const string Route = "{Id:int}";
  public int Id { get; set; }
}
