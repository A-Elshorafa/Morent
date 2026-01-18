namespace Morent.Web.Features.User.Delete;

public class DeleteUserRequest
{
  public const string Route = "{Id:int}";
  public int Id { get; set; }
}
