namespace Morent.Web.Features.Car.Delete;

public class DeleteCarRequest
{
  public const string Route = "{Id:int}";
  public int Id { get; set; }
}
