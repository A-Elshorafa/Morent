using FluentValidation;

namespace Morent.Web.Features.Car.Update;

public class UpdateCarValidator : Validator<UpdateCarRequest>
{
  public UpdateCarValidator()
  {
    RuleFor(x => x.Id).GreaterThan(0);
    RuleFor(x => x.Name).NotEmpty();
  }
}
