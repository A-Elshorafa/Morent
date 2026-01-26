using Morent.UseCases.DTOs;
using Morent.Core.Entities;

namespace Morent.UseCases.Features.Cars.Create;

public class CreateCarHandler : MediatR.IRequestHandler<CreateCarCommand, Result<CarInfoCardDto>>
{
  private readonly IRepository<Car> _repo;
  private readonly IReadRepository<CarType> _carTypeRepo;

  public CreateCarHandler(IRepository<Car> repo,  IReadRepository<CarType> carTypeRepo)
  {
    _repo = repo;
    _carTypeRepo = carTypeRepo;
  }

  public async Task<Result<CarInfoCardDto>> Handle(CreateCarCommand request, CancellationToken ct)
  {
    try
    {
      var entity = new Car
      {
        ModelName = request.carDto.ModelName,
        RentalPrice = request.carDto.RentalPrice,
        LicensePlate = request.carDto.LicensePlate,
        Description = request.carDto.Description,
        Year = request.carDto.Year,
        Color = request.carDto.Color, 
        NoOfPassengers = request.carDto.NoOfPassengers,
        FuelCapacity = request.carDto.FuelCapacity,
        IsAutomatic = request.carDto.IsAutomatic,
        IsAvailable = request.carDto.IsAvailable,
        IsPopular = request.carDto.IsPopular,
        PhotoUrl = request.carDto.PhotoUrl,
        CarTypeId = request.carDto.CarTypeId,
        OwnerId = request.carDto.OwnerId,
        CompanyId = request.carDto.CompanyId,
      };

      await _repo.AddAsync(entity, ct);
      entity.CarType = await _carTypeRepo.GetByIdAsync(entity.CarTypeId) ?? new CarType();

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
    catch (Exception ex)
    {
      return Result.Error(ex.Message);
    }
  }
}
