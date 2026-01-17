namespace Morent.UseCases.Features.CarTypes.Delete;

public record DeleteCarTypeCommand(int CarTypeId) : MediatR.IRequest<Result<bool>>;

