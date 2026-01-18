using Morent.UseCases.DTOs;

namespace Morent.UseCases.Features.Users.GetAll;

public record GetUserAllQuery() : MediatR.IRequest<Result<List<UserDto>>>;
