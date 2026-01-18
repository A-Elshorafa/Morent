using Morent.UseCases.DTOs;

namespace Morent.UseCases.Features.Users.Update;

public record UpdateUserCommand(UpdateUserDto updateUserDto) : MediatR.IRequest<Result<UserDto>>;
