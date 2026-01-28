using Morent.Core.DTOs;

namespace Morent.UseCases.Features.Auth;

public sealed record LoginCommand(string Email, string Password) : MediatR.IRequest<Result<LoginResponseDto>>;

