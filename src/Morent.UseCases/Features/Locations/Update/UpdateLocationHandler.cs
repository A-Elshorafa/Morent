using Morent.Core.Entities;
using Morent.Core.DTOs;

namespace Morent.UseCases.Features.Locations.Update;

public class UpdateLocationHandler : MediatR.IRequestHandler<UpdateLocationCommand, Result<LocationDto>>
{
  private readonly IRepository<Location> _repo;

  public UpdateLocationHandler(IRepository<Location> repo)
  {
    _repo = repo;
  }

  public async Task<Result<LocationDto>> Handle(UpdateLocationCommand request, CancellationToken ct)
  {
    var entity = await _repo.GetByIdAsync(request.Id, ct);
    if (entity == null) return Result.NotFound("Location not found");

    entity.LocationName = request.Name;

    await _repo.UpdateAsync(entity, ct);

    return Result.Success(new LocationDto(){ LocationId = entity.LocationId, LocationName = entity.LocationName });
  }
}
