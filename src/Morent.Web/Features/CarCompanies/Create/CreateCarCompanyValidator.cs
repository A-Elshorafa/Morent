using FluentValidation;

namespace Morent.Web.Features.CarCompanies.Create;

public class CreateCarCompanyValidator : Validator<CreateCarCompanyRequest>
{
  public CreateCarCompanyValidator()
  {
    RuleFor(x => x.CompanyName).NotEmpty().WithMessage("Company name is required");
  }
}
