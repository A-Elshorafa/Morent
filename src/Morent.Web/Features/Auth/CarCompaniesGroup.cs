namespace Morent.Web.Features.CarCompanies;

public class AuthGroup : Group
{
  public AuthGroup()
  {
    Configure("auth",ep => ep.AllowAnonymous());
  }
}
