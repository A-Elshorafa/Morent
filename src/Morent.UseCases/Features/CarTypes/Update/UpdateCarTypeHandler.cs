using Morent.Core.Entities;

namespace Morent.UseCases.Features.CarTypes.Update;

public sealed class UpdateCarTypeHandler : MediatR.IRequestHandler<UpdateCarTypeCommand, Result<bool>>
{
  private readonly IRepository<CarType> _repo;

  public UpdateCarTypeHandler(IRepository<CarType> repo)
  {
    _repo = repo;
  }

  public async Task<Result<bool>> Handle(UpdateCarTypeCommand request, CancellationToken ct)
  {
    var entity = await _repo.GetByIdAsync(request.CarTypeId, ct);
    if (entity == null) return false;

    entity.TypeName = request.TypeName;
    await _repo.UpdateAsync(entity, ct);

    return true;
  }
}
