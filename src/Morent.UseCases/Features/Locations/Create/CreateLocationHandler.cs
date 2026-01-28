using Morent.Core.Entities;
using Morent.Core.DTOs;

namespace Morent.UseCases.Features.Locations.Create;

public class CreateLocationHandler : MediatR.IRequestHandler<CreateLocationCommand, Result<LocationDto>>
{
  private readonly IRepository<Location> _repo;

  public CreateLocationHandler(IRepository<Location> repo)
  {
    _repo = repo;
  }

  public async Task<Result<LocationDto>> Handle(CreateLocationCommand request, CancellationToken ct)
  {
    var entity = new Location { LocationName = request.Name };

    await _repo.AddAsync(entity, ct);

    return Result.Success(new LocationDto(){ LocationId = entity.LocationId, LocationName = entity.LocationName });
  }
}
