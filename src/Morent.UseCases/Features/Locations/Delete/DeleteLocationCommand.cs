namespace Morent.UseCases.Features.Locations.Delete;

public record DeleteLocationCommand(int Id) : MediatR.IRequest<Result<bool>>;
