using FluentValidation;

namespace Morent.Web.Features.Locations.Delete;

public class DeleteLocationValidator : Validator<DeleteLocationRequest>
{
  public DeleteLocationValidator()
  {
    RuleFor(x => x.Id).GreaterThan(0);
  }
}
