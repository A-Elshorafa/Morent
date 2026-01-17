using FluentValidation;

namespace Morent.Web.Features.CarCompanies.Update;

public class UpdateCarCompanyValidator : Validator<UpdateCarCompanyRequest>
{
  public UpdateCarCompanyValidator()
  {
    RuleFor(x => x.CompanyId).GreaterThan(0);
    RuleFor(x => x.CompanyName).NotEmpty().MinimumLength(2);
  }
}
