using FastEndpoints;

namespace Morent.Web.Features.Locations;

public class LocationGroup : Group
{
  public LocationGroup()
  {
    Configure("locations", g => g.AllowAnonymous());
  }
}
