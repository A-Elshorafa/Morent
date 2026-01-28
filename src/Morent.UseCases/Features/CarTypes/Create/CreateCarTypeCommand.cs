using Morent.Core.DTOs;

namespace Morent.UseCases.Features.CarTypes.Create;

public record CreateCarTypeCommand(string TypeName) 
  : MediatR.IRequest<Result<CarTypeDto>>;
