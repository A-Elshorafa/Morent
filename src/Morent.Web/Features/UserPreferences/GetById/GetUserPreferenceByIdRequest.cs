namespace Morent.Web.Features.UserPreferences.GetById;

public class GetUserPreferenceByIdRequest
{
  public const string Route = "{Id:int}";
  public int Id { get; set; }
}
