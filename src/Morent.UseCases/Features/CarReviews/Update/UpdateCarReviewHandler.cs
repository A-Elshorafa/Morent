using Morent.UseCases.DTOs;
using Morent.Core.Entities;

namespace Morent.UseCases.Features.CarReviews.Update;

public class UpdateCarReviewHandler : MediatR.IRequestHandler<UpdateCarReviewCommand, Result<GetCarReviewDto>>
{
  private readonly IRepository<CarReview> _repo;

  public UpdateCarReviewHandler(IRepository<CarReview> repo)
  {
    _repo = repo;
  }

  public async Task<Result<GetCarReviewDto>> Handle(UpdateCarReviewCommand request, CancellationToken ct)
  {
    var entity = await _repo.GetByIdAsync((int)request.reviewDto.CarReviewId!, ct);
    if (entity == null) return Result.NotFound("CarReview not found");

    if(request.reviewDto.CarId != entity.CarId) entity.CarId = (int)request.reviewDto.CarId!;
    if(request.reviewDto.UserId != entity.UserId) entity.UserId = (int)request.reviewDto.UserId!;
    if(request.reviewDto.Rating != entity.Rating) entity.Rating = (int)request.reviewDto.Rating!;
    if(request.reviewDto.ReviewText != entity.ReviewText) entity.ReviewText = request.reviewDto.ReviewText ?? string.Empty;

    await _repo.UpdateAsync(entity, ct);

    return Result.Success(new GetCarReviewDto(entity.CarId, entity.UserId, entity.Rating, entity.ReviewText, entity.CarReviewId));
  }
}
