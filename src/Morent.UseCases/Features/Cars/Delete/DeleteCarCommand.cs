namespace Morent.UseCases.Features.Cars.Delete;

public record DeleteCarCommand(int Id) : MediatR.IRequest<Result<bool>>;
