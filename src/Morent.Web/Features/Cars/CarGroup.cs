using FastEndpoints;

namespace Morent.Web.Features.Car;

public class CarGroup : Group
{
  public CarGroup()
  {
    Configure("cars", definition => { });
  }
}
