namespace Morent.Web.Features.CarType;

public class CarTypesGroup : Group
{
  public CarTypesGroup()
  {
    Configure("car-types", ep => ep.AllowAnonymous());
  }
}
