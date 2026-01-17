using Morent.Core.Entities;
using Morent.UseCases.DTOs;

namespace Morent.UseCases.Features.Locations.GetAll;

public class GetLocationAllHandler : MediatR.IRequestHandler<GetLocationAllQuery, Result<List<LocationDto>>>
{
  private readonly IRepository<Location> _repo;

  public GetLocationAllHandler(IRepository<Location> repo)
  {
    _repo = repo;
  }

  public async Task<Result<List<LocationDto>>> Handle(GetLocationAllQuery request, CancellationToken ct)
  {
    var list = await _repo.ListAsync(ct);

    return Result.Success(list
      .Select(x => new LocationDto() {LocationId = x.LocationId, LocationName = x.LocationName })
      .ToList());
  }
}
