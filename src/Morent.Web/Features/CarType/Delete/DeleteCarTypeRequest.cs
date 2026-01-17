namespace Morent.Web.Features.CarType.Delete;

public class DeleteCarTypeRequest
{
  public const string Route = "/{id}";
  public int Id { get; set; }
}
