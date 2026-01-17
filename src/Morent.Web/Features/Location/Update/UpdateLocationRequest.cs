namespace Morent.Web.Features.Location.Update;

public class UpdateLocationRequest
{
  public const string Route = "{Id:int}";
  public int Id { get; set; }
  public string Name { get; set; } = "";
}
