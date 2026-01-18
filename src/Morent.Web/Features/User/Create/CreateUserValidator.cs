using FluentValidation;
namespace Morent.Web.Features.User.Create;

public class CreateUserValidator : Validator<CreateUserRequest>
{
  public CreateUserValidator()
  {
    RuleFor(x => x.FullName)
      .NotEmpty().MaximumLength(100);

    RuleFor(x => x.Email)
      .NotEmpty().EmailAddress();

    RuleFor(x => x.PhoneNumber)
      .NotEmpty().MaximumLength(20);

    RuleFor(x => x.NationalID)
      .NotEmpty().Length(14);

    RuleFor(x => x.DateOfBirth)
      .LessThan(DateTime.Today).WithMessage("Invalid birth date.");

    RuleFor(x => x.Address)
      .NotEmpty().MaximumLength(250);

    RuleFor(x => x.DrivingLicenseNumber)
      .NotEmpty().MaximumLength(50);

    RuleFor(x => x.JobRole)
      .NotEmpty().MaximumLength(50);

    RuleFor(x => x.PhotoUrl)
      .NotEmpty().WithMessage("Invalid Photo URL.");
  }
}
