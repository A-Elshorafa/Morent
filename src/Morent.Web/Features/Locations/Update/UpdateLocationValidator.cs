using FluentValidation;

namespace Morent.Web.Features.Locations.Update;

public class UpdateLocationValidator : Validator<UpdateLocationRequest>
{
  public UpdateLocationValidator()
  {
    RuleFor(x => x.Id).GreaterThan(0);
    RuleFor(x => x.Name).NotEmpty();
  }
}
