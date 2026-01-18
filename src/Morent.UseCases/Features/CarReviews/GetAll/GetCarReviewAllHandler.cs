using Morent.UseCases.DTOs;
using Morent.Core.Entities;

namespace Morent.UseCases.Features.CarReviews.GetAll;

public class GetCarReviewAllHandler : MediatR.IRequestHandler<GetCarReviewAllQuery, Result<List<GetCarReviewDto>>>
{
  private readonly IRepository<CarReview> _repo;

  public GetCarReviewAllHandler(IRepository<CarReview> repo)
  {
    _repo = repo;
  }

  public async Task<Result<List<GetCarReviewDto>>> Handle(GetCarReviewAllQuery request, CancellationToken ct)
  {
    var list = await _repo.ListAsync(ct);

    return Result.Success(list
      .Select(x => new GetCarReviewDto(x.CarId, x.UserId, x.Rating, x.ReviewText, x.CarReviewId))
      .ToList());
  }
}
