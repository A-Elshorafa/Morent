using FluentValidation;

namespace Morent.Web.Features.UserPreferences.Delete;

public class DeleteUserPreferenceValidator : Validator<DeleteUserPreferenceRequest>
{
  public DeleteUserPreferenceValidator()
  {
    RuleFor(x => x.Id).GreaterThan(0);
  }
}
