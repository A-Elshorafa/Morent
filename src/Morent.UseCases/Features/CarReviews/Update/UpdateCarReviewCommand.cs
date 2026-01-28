using Morent.Core.DTOs;

namespace Morent.UseCases.Features.CarReviews.Update;

public record UpdateCarReviewCommand(UpdateCarReviewDto reviewDto) : MediatR.IRequest<Result<GetCarReviewDto>>;
