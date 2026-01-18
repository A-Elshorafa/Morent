using Morent.UseCases.DTOs;

namespace Morent.UseCases.Features.Users.Create;

public record CreateUserCommand(CreateUserDto userDto) : MediatR.IRequest<Result<UserDto>>;
