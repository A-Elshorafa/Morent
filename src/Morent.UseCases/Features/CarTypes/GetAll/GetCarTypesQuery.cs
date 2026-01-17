using Morent.UseCases.DTOs;

namespace Morent.UseCases.Features.CarTypes.GetAll;

public record GetCarTypesQuery() : MediatR.IRequest<Result<IReadOnlyList<CarTypeDto>>>;
