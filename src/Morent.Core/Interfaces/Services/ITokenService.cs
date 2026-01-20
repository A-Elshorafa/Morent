using Morent.Core.Entities;

namespace Morent.Core.Interfaces.Services;

public interface ITokenService
{
  string GenerateToken(User user);
}
