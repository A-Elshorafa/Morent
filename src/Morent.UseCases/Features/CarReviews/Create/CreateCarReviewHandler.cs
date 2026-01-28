using Morent.Core.DTOs;
using Morent.Core.Entities;

namespace Morent.UseCases.Features.CarReviews.Create;

public class CreateCarReviewHandler : MediatR.IRequestHandler<CreateCarReviewCommand, Result<GetCarReviewDto>>
{
  private readonly IRepository<CarReview> _repo;

  public CreateCarReviewHandler(IRepository<CarReview> repo)
  {
    _repo = repo;
  }

  public async Task<Result<GetCarReviewDto>> Handle(CreateCarReviewCommand request, CancellationToken ct)
  {
    var entity = new CarReview
    {
       CarId = (int)request.reviewDto.CarId!,
       UserId = (int)request.reviewDto.UserId!,
       Rating  = (int)request.reviewDto.Rating!,
       ReviewText  = request.reviewDto.ReviewText ?? string.Empty,
    };

    await _repo.AddAsync(entity, ct);

    return Result.Success(new GetCarReviewDto(entity.CarId, entity.UserId, entity.Rating, entity.ReviewText, entity.CarReviewId));
  }
}
