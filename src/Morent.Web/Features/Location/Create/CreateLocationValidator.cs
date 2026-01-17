using FluentValidation;

namespace Morent.Web.Features.Location.Create;

public class CreateLocationValidator : Validator<CreateLocationRequest>
{
  public CreateLocationValidator()
  {
    RuleFor(x => x.Name).NotEmpty().MinimumLength(2);
  }
}
