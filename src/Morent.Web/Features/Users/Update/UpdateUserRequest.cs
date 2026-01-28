using Morent.Core.DTOs;

namespace Morent.Web.Features.Users.Update;

public class UpdateUserRequest : UpdateUserDto
{
  public const string Route = "{Id:int}";
}
