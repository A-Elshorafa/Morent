using Morent.Core.Entities;
using Morent.Core.Specifications.Cars;
using Morent.UseCases.DTOs;

namespace Morent.UseCases.Features.Cars.GetRecommendedCars;

public sealed class GetRecommendedCarsHandler
  : MediatR.IRequestHandler<GetRecommendedCarsQuery, Result<IReadOnlyList<CarInfoCardDto>>>
{
  private readonly IReadRepository<Car> _carRepository;

  public GetRecommendedCarsHandler(IReadRepository<Car> carRepository)
  {
    _carRepository = carRepository;
  }

  public async Task<Result<IReadOnlyList<CarInfoCardDto>>> Handle(
    GetRecommendedCarsQuery request,
    CancellationToken cancellationToken)
  {
    var spec = new RecommendedCarsSpec(request.PageIndex, request.PageSize);

    var cars = await _carRepository.ListAsync(spec, cancellationToken);

    var carsList = cars.Select(c => new CarInfoCardDto
    {
      ModelName = c.ModelName,
      RentalPrice = c.RentalPrice,
      TypeName = c.CarType.TypeName,
      IsPreferred = c.IsPopular,
      PhotoURL = c.PhotoUrl,
      FuelCapacity = c.FuelCapacity,
      IsAutomatic = c.IsAutomatic,
      NoOfPassengers = c.NoOfPassengers
    }).ToList();

    return Result<IReadOnlyList<CarInfoCardDto>>.Success(carsList);
  }
}
