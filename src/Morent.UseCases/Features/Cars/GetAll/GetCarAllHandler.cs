using Morent.UseCases.DTOs;
using Morent.Core.Entities;
using Morent.Core.Specifications.CarSpecs;

namespace Morent.UseCases.Features.Cars.GetAll;

public class GetCarAllHandler : MediatR.IRequestHandler<GetCarAllQuery, Result<List<CarInfoCardDto>>>
{
  private readonly IRepository<Car> _repo;

  public GetCarAllHandler(IRepository<Car> repo)
  {
    _repo = repo;
  }

  public async Task<Result<List<CarInfoCardDto>>> Handle(GetCarAllQuery request, CancellationToken ct)
  {
    var list = await _repo.ListAsync(new CarWithTypeSpec(), ct);

    return Result.Success(
      list.Select(entity => new CarInfoCardDto(
          entity.CarId,
          entity.ModelName,
          entity.FuelCapacity,
          entity.NoOfPassengers,
          entity.IsAutomatic,
          entity.RentalPrice,
          entity.CarType.TypeName,
          entity.IsPopular,
          entity.PhotoUrl
        )
        {
          ModelName = entity.ModelName,
          TypeName = entity.CarType.TypeName,
          IsPreferred = false,
        })
      .ToList()
      );
  }
}
