using Morent.UseCases.DTOs;
using Morent.Core.Entities;

namespace Morent.UseCases.Features.CarReviews.Delete;

public class DeleteCarReviewHandler : MediatR.IRequestHandler<DeleteCarReviewCommand, Result<bool>>
{
  private readonly IRepository<CarReview> _repo;

  public DeleteCarReviewHandler(IRepository<CarReview> repo)
  {
    _repo = repo;
  }

  public async Task<Result<bool>> Handle(DeleteCarReviewCommand request, CancellationToken ct)
  {
    var entity = await _repo.GetByIdAsync(request.Id, ct);
    if (entity == null) return Result.NotFound("CarReview not found");

    await _repo.DeleteAsync(entity, ct);

    return Result.Success(true);
  }
}
