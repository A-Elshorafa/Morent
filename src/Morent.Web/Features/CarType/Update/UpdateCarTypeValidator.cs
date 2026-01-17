using FluentValidation;

namespace Morent.Web.Features.CarType.Update;

public class UpdateCarTypeValidator : Validator<UpdateCarTypeRequest>
{
  public UpdateCarTypeValidator()
  {
    RuleFor(x => x.Id).GreaterThan(0);

    RuleFor(x => x.TypeName)
      .NotEmpty()
      .MinimumLength(2);
  }
}
