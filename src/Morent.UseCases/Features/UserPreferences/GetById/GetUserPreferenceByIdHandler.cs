using Morent.Core.DTOs;
using Morent.Core.Entities;
using Morent.Core.Specifications.UserPreferenceSpecs;

namespace Morent.UseCases.Features.UserPreferences.GetById;

public class GetUserPreferenceByIdHandler : MediatR.IRequestHandler<GetUserPreferenceByIdQuery, Result<UserPreferenceDto>>
{
  private readonly IRepository<UserPreference> _repo;

  public GetUserPreferenceByIdHandler(IRepository<UserPreference> repo)
  {
    _repo = repo;
  }

  public async Task<Result<UserPreferenceDto>> Handle(GetUserPreferenceByIdQuery request, CancellationToken ct)
  {
    var entity = await _repo.FirstOrDefaultAsync(new UserPreferenceWithCarSpec(request.Id), ct);
    if (entity == null) return Result.NotFound("UserPreference not found");

    return Result.Success(new UserPreferenceDto(entity.UserPreferencesId, entity.Car, true, entity.Car.CarType.TypeName));
  }
}
