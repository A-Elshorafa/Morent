namespace Morent.UseCases.Features.CarTypes.Update;

public record UpdateCarTypeCommand(int CarTypeId, string TypeName)
  : MediatR.IRequest<Result<bool>>;

