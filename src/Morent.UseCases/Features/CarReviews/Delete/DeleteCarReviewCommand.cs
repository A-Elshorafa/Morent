namespace Morent.UseCases.Features.CarReviews.Delete;

public record DeleteCarReviewCommand(int Id) : MediatR.IRequest<Result<bool>>;
