using FluentValidation;

namespace Morent.Web.Features.Car.Delete;

public class DeleteCarValidator : Validator<DeleteCarRequest>
{
  public DeleteCarValidator()
  {
    RuleFor(x => x.Id).GreaterThan(0);
  }
}
