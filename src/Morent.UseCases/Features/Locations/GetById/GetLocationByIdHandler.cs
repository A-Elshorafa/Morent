using Morent.Core.Entities;
using Morent.UseCases.DTOs;

namespace Morent.UseCases.Features.Locations.GetById;

public class GetLocationByIdHandler : MediatR.IRequestHandler<GetLocationByIdQuery, Result<LocationDto>>
{
  private readonly IRepository<Location> _repo;

  public GetLocationByIdHandler(IRepository<Location> repo)
  {
    _repo = repo;
  }

  public async Task<Result<LocationDto>> Handle(GetLocationByIdQuery request, CancellationToken ct)
  {
    var entity = await _repo.GetByIdAsync(request.Id, ct);
    if (entity == null) return Result.NotFound("Location not found");

    return Result.Success(new LocationDto(){LocationId = entity.LocationId, LocationName = entity.LocationName});
  }
}
