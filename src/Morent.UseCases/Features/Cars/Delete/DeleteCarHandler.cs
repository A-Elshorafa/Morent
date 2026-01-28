using Morent.Core.DTOs;
using Morent.Core.Entities;

namespace Morent.UseCases.Features.Cars.Delete;

public class DeleteCarHandler : MediatR.IRequestHandler<DeleteCarCommand, Result<bool>>
{
  private readonly IRepository<Car> _repo;

  public DeleteCarHandler(IRepository<Car> repo)
  {
    _repo = repo;
  }

  public async Task<Result<bool>> Handle(DeleteCarCommand request, CancellationToken ct)
  {
    var entity = await _repo.GetByIdAsync(request.Id, ct);
    if (entity == null) return Result.NotFound("Car not found");

    await _repo.DeleteAsync(entity, ct);

    return Result.Success(true);
  }
}
