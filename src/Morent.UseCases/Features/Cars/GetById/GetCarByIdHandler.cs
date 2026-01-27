using Morent.UseCases.DTOs;
using Morent.Core.Entities;
using Morent.Core.Specifications.CarSpecs;

namespace Morent.UseCases.Features.Cars.GetById;

public class GetCarByIdHandler : MediatR.IRequestHandler<GetCarByIdQuery, Result<CarInfoCardDto>>
{
  private readonly IRepository<Car> _repo;

  public GetCarByIdHandler(IRepository<Car> repo)
  {
    _repo = repo;
  }

  public async Task<Result<CarInfoCardDto>> Handle(GetCarByIdQuery request, CancellationToken ct)
  {
    var entity = await _repo.FirstOrDefaultAsync(new CarWithTypeSpec(request.Id), ct);
    if (entity == null) return Result.NotFound("Car not found");

    return Result.Success(new CarInfoCardDto(
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
    });
  }
}
