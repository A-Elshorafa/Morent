namespace Morent.Web.Features.CarTypes;

public class CarTypesGroup : Group
{
  public CarTypesGroup()
  {
    Configure("car-types", ep => ep.AllowAnonymous());
  }
}
