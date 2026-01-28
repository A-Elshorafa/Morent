namespace Morent.Core.DTOs;

public sealed class LoginResponseDto
{
  public string Token { get; set; } = null!;
  public string Email { get; set; } = null!;
}
