namespace Morent.Web.Features.UserPreferences.Delete;

public class DeleteUserPreferenceRequest
{
  public const string Route = "{Id:int}";
  public int Id { get; set; }
}
