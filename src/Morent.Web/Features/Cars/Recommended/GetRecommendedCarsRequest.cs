using API = Microsoft.AspNetCore.Mvc;
namespace Morent.Web.Endpoints.Cars.Recommended;

public class GetRecommendedCarsRequest
{
  public static string Route = "/get-recommended-cars";
  
  [API.FromQuery]
  public int PageIndex { get; init; } = 0;
  [API.FromQuery]
  public int PageSize { get; init; } = 10;
}
