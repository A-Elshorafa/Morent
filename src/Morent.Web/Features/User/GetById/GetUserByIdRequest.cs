namespace Morent.Web.Features.User.GetById;

public class GetUserByIdRequest
{
  public const string Route = "{Id:int}";
  public int Id { get; set; }
}
