using FluentValidation;

namespace Morent.Web.Features.Users.Update;

public class UpdateUserValidator : Validator<UpdateUserRequest>
{
  public UpdateUserValidator()
  {
    RuleFor(x => x.UserId)
      .GreaterThan(0);

    RuleFor(x => x.FullName)
      .MaximumLength(100)
      .When(x => x.FullName != null);

    RuleFor(x => x.Email)
      .EmailAddress()
      .When(x => x.Email != null);

    RuleFor(x => x.PhoneNumber)
      .MaximumLength(20)
      .When(x => x.PhoneNumber != null);

    RuleFor(x => x.NationalID)
      .Length(14)
      .When(x => x.NationalID != null);

    RuleFor(x => x.DateOfBirth)
      .LessThan(DateTime.Today)
      .When(x => x.DateOfBirth != null);
  }
}
