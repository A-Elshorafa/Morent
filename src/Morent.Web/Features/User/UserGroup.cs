using FastEndpoints;

namespace Morent.Web.Features.User;

public class UserGroup : Group
{
  public UserGroup()
  {
    Configure("user", g => g.AllowAnonymous());
  }
}
