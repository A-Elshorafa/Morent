using System.Security.Claims;

namespace Morent.Web.Handlers;

public class ClaimHandler
{
  private readonly IHttpContextAccessor _http;

  public ClaimHandler(IHttpContextAccessor http)
  {
    _http = http;
  }

  public int GetCurrentUserId()
  {
    return int.Parse(_http.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier)!);
  }
}
