namespace Morent.Web.Features.Locations.Delete;

public class DeleteLocationRequest
{
  public const string Route = "{Id:int}";
  public int Id { get; set; }
}
