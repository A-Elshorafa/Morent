namespace Morent.Web.Features.Location.GetById;

public class GetLocationByIdRequest
{
  public const string Route = "{Id:int}";
  public int Id { get; set; }
}
