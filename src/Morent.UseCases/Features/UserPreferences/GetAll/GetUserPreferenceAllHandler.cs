using Morent.Core.DTOs;
using Morent.Core.Entities;
using Morent.Core.Specifications.UserPreferenceSpecs;

namespace Morent.UseCases.Features.UserPreferences.GetAll;

public class GetUserPreferenceAllHandler : MediatR.IRequestHandler<GetUserPreferenceAllQuery, Result<List<UserPreferenceDto>>>
{
  private readonly IRepository<UserPreference> _repo;

  public GetUserPreferenceAllHandler(IRepository<UserPreference> repo)
  {
    _repo = repo;
  }

  public async Task<Result<List<UserPreferenceDto>>> Handle(GetUserPreferenceAllQuery request, CancellationToken ct)
  {
    var list = await _repo.ListAsync(new UserPreferenceWithCarSpec() ,ct);

    return Result.Success(list
      .Select(x => new UserPreferenceDto(x.UserPreferencesId, x.Car, true, x.Car.CarType.TypeName))
      .ToList());
  }
}
