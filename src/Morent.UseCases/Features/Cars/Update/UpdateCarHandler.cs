using Morent.UseCases.DTOs;
using Morent.Core.Entities;

namespace Morent.UseCases.Features.Cars.Update;

public class UpdateCarHandler : MediatR.IRequestHandler<UpdateCarCommand, Result<CarInfoCardDto>>
{
  private readonly IRepository<Car> _repo;

  public UpdateCarHandler(IRepository<Car> repo)
  {
    _repo = repo;
  }

  public async Task<Result<CarInfoCardDto>> Handle(UpdateCarCommand request, CancellationToken ct)
  {
    var entity = await _repo.GetByIdAsync(request.carDto.CarId, ct);
    if (entity == null) return Result.NotFound("Car not found");

    if (request.carDto.ModelName != entity.ModelName)
      entity.ModelName = request.carDto.ModelName;
    
    if (request.carDto.PhotoUrl != entity.PhotoUrl)
      entity.PhotoUrl = request.carDto.PhotoUrl;
    
    if (request.carDto.FuelCapacity != entity.FuelCapacity)
      entity.FuelCapacity = request.carDto.FuelCapacity;
    
    if (request.carDto.Description != entity.Description)
      entity.Description = request.carDto.Description;
    
    if (request.carDto.LicensePlate != entity.LicensePlate)
      entity.LicensePlate = request.carDto.LicensePlate;
    
    if (request.carDto.NoOfPassengers != entity.NoOfPassengers)
      entity.NoOfPassengers = request.carDto.NoOfPassengers;
    
    if (request.carDto.RentalPrice != entity.RentalPrice)
      entity.RentalPrice = request.carDto.RentalPrice;
    
    if (request.carDto.CompanyId != entity.CompanyId)
      entity.CompanyId = request.carDto.CompanyId;
    
    if (request.carDto.Description != entity.Description)
      entity.Description = request.carDto.Description;

    if (request.carDto.IsAutomatic != entity.IsAutomatic)
      entity.IsAutomatic = request.carDto.IsAutomatic;
      
    if (request.carDto.IsAvailable != entity.IsAvailable)
      entity.IsAvailable = request.carDto.IsAvailable;
    
    if (request.carDto.Color != entity.Color)
      entity.Color = request.carDto.Color;
    
    if (request.carDto.Year != entity.Year)
      entity.Year = request.carDto.Year;
    
    if (request.carDto.CarTypeId != entity.CarTypeId)
      entity.CarTypeId = request.carDto.CarTypeId;
    await _repo.UpdateAsync(entity, ct);

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
