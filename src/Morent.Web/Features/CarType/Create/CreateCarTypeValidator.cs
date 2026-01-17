using FluentValidation;

namespace Morent.Web.Features.CarType.Create;

public class CreateCarTypeValidator : Validator<CreateCarTypeRequest>
{
  public CreateCarTypeValidator()
  {
    RuleFor(x => x.TypeName)
      .NotEmpty()
      .MinimumLength(2);
  }
}
