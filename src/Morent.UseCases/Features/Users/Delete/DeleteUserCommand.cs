namespace Morent.UseCases.Features.Users.Delete;

public record DeleteUserCommand(int Id) : MediatR.IRequest<Result<bool>>;
