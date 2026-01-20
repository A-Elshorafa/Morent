namespace Morent.Web.Features.Car.GetAll;

public class GetCarAllRequest
{
  public static string Route = "";
  
  public int PageIndex { get; init; } = 0;
  public int PageSize { get; init; } = 10;
}
