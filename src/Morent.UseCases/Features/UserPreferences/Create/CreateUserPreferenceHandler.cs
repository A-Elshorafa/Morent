using Morent.Core.DTOs;
using Morent.Core.Entities;
using Morent.Core.Specifications.CarSpecs;

namespace Morent.UseCases.Features.UserPreferences.Create;

public class CreateUserPreferenceHandler : MediatR.IRequestHandler<CreateUserPreferenceCommand, Result<UserPreferenceDto>>
{
  private readonly IRepository<Car> _carRepo;
  private readonly IRepository<UserPreference> _repo;

  public CreateUserPreferenceHandler(IRepository<Car> carRepo, IRepository<CarType> carTypeRepo, IRepository<UserPreference> repo)
  {
    _repo = repo;
    _carRepo = carRepo;
  }

  public async Task<Result<UserPreferenceDto>> Handle(CreateUserPreferenceCommand request, CancellationToken ct)
  {
    var entity = new UserPreference
    {
      CarId = request.userPreferenceDto.CarId,
      UserId = request.userPreferenceDto.UserId,
    };

    var createdUserPreference = await _repo.AddAsync(entity, ct);
    if(createdUserPreference == null) return Result.Error("An error occured while create the user preference.");
    
    var carData = await _carRepo.FirstOrDefaultAsync(new CarWithTypeSpec(createdUserPreference.CarId));
    if(carData == null) return Result.Error("An error occured while getting the car details.");
    
    return Result.Success(new UserPreferenceDto(createdUserPreference.UserPreferencesId, carData, true, carData.CarType.TypeName));
  }
}
