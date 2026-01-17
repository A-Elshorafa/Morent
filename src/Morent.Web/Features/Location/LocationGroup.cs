using FastEndpoints;

namespace Morent.Web.Features.Location;

public class LocationGroup : Group
{
  public LocationGroup()
  {
    Configure("location", g => g.AllowAnonymous());
  }
}
