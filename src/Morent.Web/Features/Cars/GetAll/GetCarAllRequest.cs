namespace Morent.Web.Features.Car.GetAll;

public class GetCarAllRequest
{
  public static string Route = "";
  
  public int PageSize { get; init; } = 10;
  public int PageNumber { get; init; } = 1;
  public string SearchToken { get; init; } = string.Empty;
}
