namespace Morent.Web.Features.CarTypes.Delete;

public class DeleteCarTypeRequest
{
  public const string Route = "/{id}";
  public int Id { get; set; }
}
