using FluentValidation;

namespace Morent.Web.Features.CarReviews.Update;

public class UpdateCarReviewValidator : Validator<UpdateCarReviewRequest>
{
  public UpdateCarReviewValidator()
  {
    RuleFor(x => x.CarReviewId)
      .GreaterThan(0)
      .When(x => x.CarReviewId.HasValue)
      .WithMessage("CarReviewId must be greater than 0.");
    
    RuleFor(x => x.CarId)
      .GreaterThan(0)
      .When(x => x.CarId.HasValue)
      .WithMessage("CarId must be greater than 0.");

    RuleFor(x => x.UserId)
      .GreaterThan(0)
      .When(x => x.UserId.HasValue)
      .WithMessage("UserId must be greater than 0.");

    RuleFor(x => x.Rating)
      .InclusiveBetween(1, 5)
      .When(x => x.Rating.HasValue)
      .WithMessage("Rating must be between 1 and 5.");

    RuleFor(x => x.ReviewText)
      .NotEmpty()
      .MaximumLength(500)
      .When(x => x.ReviewText != null)
      .WithMessage("ReviewText must not be empty and must be less than 500 characters.");
  }
}
