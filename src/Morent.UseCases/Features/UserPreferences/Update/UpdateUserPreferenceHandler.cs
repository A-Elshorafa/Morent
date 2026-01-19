using Morent.UseCases.DTOs;
using Morent.Core.Entities;

namespace Morent.UseCases.Features.UserPreferences.Update;

public class UpdateUserPreferenceHandler : MediatR.IRequestHandler<UpdateUserPreferenceCommand, Result<UserPreferenceDto>>
{
  private readonly IRepository<UserPreference> _repo;

  public UpdateUserPreferenceHandler(IRepository<UserPreference> repo)
  {
    _repo = repo;
  }

  public async Task<Result<UserPreferenceDto>> Handle(UpdateUserPreferenceCommand request, CancellationToken ct)
  {
    var entity = await _repo.GetByIdAsync(request.userPreferenceDto.UserPreferencesId, ct);
    if (entity == null) return Result.NotFound("UserPreference not found");

    if(entity.CarId != request.userPreferenceDto.CarId) entity.CarId = request.userPreferenceDto.CarId;

    await _repo.UpdateAsync(entity, ct);

    return Result.Success(new UserPreferenceDto(entity.UserPreferencesId, entity.Car, true, entity.Car.CarType.TypeName));
  }
}
