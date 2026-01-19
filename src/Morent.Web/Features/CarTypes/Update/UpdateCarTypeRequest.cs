namespace Morent.Web.Features.CarTypes.Update;

public class UpdateCarTypeRequest
{
  public const string Route = "/{id}";

  public int Id { get; set; }
  public string TypeName { get; set; } = "";
}

