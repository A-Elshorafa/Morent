using Morent.Core.DTOs;

namespace Morent.UseCases.Features.Users.GetById;

public record GetUserByIdQuery(int Id) : MediatR.IRequest<Result<UserDto>>;
