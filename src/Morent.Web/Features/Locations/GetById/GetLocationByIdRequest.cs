namespace Morent.Web.Features.Locations.GetById;

public class GetLocationByIdRequest
{
  public const string Route = "{Id:int}";
  public int Id { get; set; }
}
