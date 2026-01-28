using Morent.Core.DTOs;

namespace Morent.UseCases.Features.CarReviews.Create;

public record CreateCarReviewCommand(CreateCarReviewDto reviewDto) : MediatR.IRequest<Result<GetCarReviewDto>>;
