using Morent.UseCases.DTOs;
using Morent.Core.Entities;

namespace Morent.UseCases.Features.CarReviews.GetById;

public class GetCarReviewByIdHandler : MediatR.IRequestHandler<GetCarReviewByIdQuery, Result<GetCarReviewDto>>
{
  private readonly IRepository<CarReview> _repo;

  public GetCarReviewByIdHandler(IRepository<CarReview> repo)
  {
    _repo = repo;
  }

  public async Task<Result<GetCarReviewDto>> Handle(GetCarReviewByIdQuery request, CancellationToken ct)
  {
    var entity = await _repo.GetByIdAsync(request.Id, ct);
    if (entity == null) return Result.NotFound("CarReview not found");

    return Result.Success(new GetCarReviewDto(entity.CarId, entity.UserId, entity.Rating, entity.ReviewText, entity.CarReviewId));
  }
}
