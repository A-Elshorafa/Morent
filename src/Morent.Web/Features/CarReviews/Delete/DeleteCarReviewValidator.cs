using FluentValidation;

namespace Morent.Web.Features.CarReviews.Delete;

public class DeleteCarReviewValidator : Validator<DeleteCarReviewRequest>
{
  public DeleteCarReviewValidator()
  {
    RuleFor(x => x.Id).GreaterThan(0);
  }
}
