using Morent.Core.DTOs;
using Morent.Core.Entities;

namespace Morent.UseCases.Features.CarTransactions.Delete;

public class DeleteCarTransactionHandler : MediatR.IRequestHandler<DeleteCarTransactionCommand, Result<bool>>
{
  private readonly IRepository<CarTransaction> _repo;

  public DeleteCarTransactionHandler(IRepository<CarTransaction> repo)
  {
    _repo = repo;
  }

  public async Task<Result<bool>> Handle(DeleteCarTransactionCommand request, CancellationToken ct)
  {
    var entity = await _repo.GetByIdAsync(request.Id, ct);
    if (entity == null) return Result.NotFound("CarTransaction not found");

    await _repo.DeleteAsync(entity, ct);

    return Result.Success(true);
  }
}
