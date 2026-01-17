using Morent.Core.Entities;

namespace Morent.UseCases.Features.CarTypes.Delete;

public sealed class DeleteCarTypeHandler : MediatR.IRequestHandler<DeleteCarTypeCommand, Result<bool>>
{
  private readonly IRepository<CarType> _repo;

  public DeleteCarTypeHandler(IRepository<CarType> repo)
  {
    _repo = repo;
  }

  public async Task<Result<bool>> Handle(DeleteCarTypeCommand request, CancellationToken ct)
  {
    var entity = await _repo.GetByIdAsync(request.CarTypeId, ct);
    if (entity == null) return Result.NotFound("Car Type not found");

    await _repo.DeleteAsync(entity, ct);
    return Result.Success(true);
  }
}
