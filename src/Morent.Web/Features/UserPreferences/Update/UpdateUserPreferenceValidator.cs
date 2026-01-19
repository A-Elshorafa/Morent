using FluentValidation;

namespace Morent.Web.Features.UserPreferences.Update;

public class UpdateUserPreferenceValidator : Validator<UpdateUserPreferenceRequest>
{
  public UpdateUserPreferenceValidator()
  {
    RuleFor(x => x.UserPreferencesId)
      .GreaterThan(0).WithMessage("User Preference Ids is required.");

    RuleFor(x => x.CarId)
      .GreaterThan(0).WithMessage("CarId is required.");

    RuleFor(x => x.UserId)
      .GreaterThan(0).WithMessage("UserId is required.");
  }
}
