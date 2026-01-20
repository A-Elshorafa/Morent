namespace Morent.Web.Endpoints.Cars.Recommended;

public class GetRecommendedCarsRequest
{
  public static string Route = "/cars/get-recommended-cars";
  
  public int PageIndex { get; init; } = 0;
  public int PageSize { get; init; } = 10;
}
