using Morent.UseCases.DTOs;

namespace Morent.Web.Features.User.Update;

public class UpdateUserRequest : UpdateUserDto
{
  public const string Route = "{Id:int}";
}
