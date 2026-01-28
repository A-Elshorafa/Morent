using Morent.Core.DTOs;

namespace Morent.UseCases.Features.CarReviews.GetAll;

public record GetCarReviewAllQuery() : MediatR.IRequest<Result<List<GetCarReviewDto>>>;
