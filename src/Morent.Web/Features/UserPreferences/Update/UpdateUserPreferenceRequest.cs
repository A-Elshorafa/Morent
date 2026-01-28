using Morent.Core.DTOs;

namespace Morent.Web.Features.UserPreferences.Update;

public class UpdateUserPreferenceRequest : UpdateUserPreferenceDto
{
  public const string Route = "{Id:int}";
}
