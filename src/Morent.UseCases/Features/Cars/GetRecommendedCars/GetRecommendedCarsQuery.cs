using Morent.UseCases.DTOs;

namespace Morent.UseCases.Features.Cars.GetRecommendedCars;

public record GetRecommendedCarsQuery(int PageIndex, int PageSize)
  : MediatR.IRequest<Result<IReadOnlyList<CarInfoCardDto>>>;
