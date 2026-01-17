namespace Morent.Web.Features.Location.Delete;

public class DeleteLocationRequest
{
  public const string Route = "{Id:int}";
  public int Id { get; set; }
}
