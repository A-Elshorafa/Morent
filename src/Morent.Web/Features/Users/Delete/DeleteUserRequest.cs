namespace Morent.Web.Features.Users.Delete;

public class DeleteUserRequest
{
  public const string Route = "{Id:int}";
  public int Id { get; set; }
}
