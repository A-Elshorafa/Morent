using FastEndpoints;

namespace Morent.Web.Features.Users;

public class UserGroup : Group
{
  public UserGroup()
  {
    Configure("users", g => g.AllowAnonymous());
  }
}
