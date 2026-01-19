using FluentValidation;
namespace Morent.Web.Features.UserPreferences.Create;

public class CreateUserPreferenceValidator : Validator<CreateUserPreferenceRequest>
{
  public CreateUserPreferenceValidator()
  {
    RuleFor(x => x.CarId)
      .GreaterThan(0).WithMessage("CarId is required.");

    RuleFor(x => x.UserId)
      .GreaterThan(0).WithMessage("UserId is required.");
  }
}
