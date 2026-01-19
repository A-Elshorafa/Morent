using FastEndpoints;

namespace Morent.Web.Features.UserPreferences;

public class UserPreferenceGroup : Group
{
  public UserPreferenceGroup()
  {
    Configure("user-preferences", g => g.AllowAnonymous());
  }
}
