using Morent.Core.Entities;
using Morent.Core.Interfaces.Services;
using Morent.Core.Specifications.AuthSpecs;
using Morent.UseCases.DTOs;

namespace Morent.UseCases.Features.Auth;

public sealed class LoginHandler : MediatR.IRequestHandler<LoginCommand, Result<LoginResponseDto>>
{
  private readonly IRepository<User> _userRepo;
  private readonly ITokenService _tokenService;

  public LoginHandler(IRepository<User> userRepo, ITokenService tokenService)
  {
    _userRepo = userRepo;
    _tokenService = tokenService;
  }

  public async Task<Result<LoginResponseDto>> Handle(LoginCommand request, CancellationToken ct)
  {
    var user = await _userRepo.FirstOrDefaultAsync(new UserByEmailSpec(request.Email), ct);
    
    if (user is null)
      return Result.NotFound("User not found");

    if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
      return Result.Conflict("Invalid password");

    var token = _tokenService.GenerateToken(user);

    return Result.Success(new LoginResponseDto
    {
      Token = token,
      Email = user.Email
    });
  }
}

