using Morent.Core.DTOs;

namespace Morent.UseCases.Features.CarReviews.GetById;

public record GetCarReviewByIdQuery(int Id) : MediatR.IRequest<Result<GetCarReviewDto>>;
