using FluentValidation;

namespace Morent.Web.Features.CarTypes.Create;

public class CreateCarTypeValidator : Validator<CreateCarTypeRequest>
{
  public CreateCarTypeValidator()
  {
    RuleFor(x => x.TypeName)
      .NotEmpty()
      .MinimumLength(2);
  }
}
