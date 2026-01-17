using Morent.Core.Entities;

namespace Morent.UseCases.Features.Locations.Delete;

public class DeleteLocationHandler : MediatR.IRequestHandler<DeleteLocationCommand, Result<bool>>
{
  private readonly IRepository<Location> _repo;

  public DeleteLocationHandler(IRepository<Location> repo)
  {
    _repo = repo;
  }

  public async Task<Result<bool>> Handle(DeleteLocationCommand request, CancellationToken ct)
  {
    var entity = await _repo.GetByIdAsync(request.Id, ct);
    if (entity == null) return Result.NotFound("Location not found");

    await _repo.DeleteAsync(entity, ct);

    return Result.Success(true);
  }
}
