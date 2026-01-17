using FluentValidation;

namespace Morent.Web.Features.CarCompanies.Delete;

public class DeleteCarCompanyValidator : Validator<DeleteCarCompanyRequest>
{
  public DeleteCarCompanyValidator()
  {
    RuleFor(x => x.CompanyId).GreaterThan(0);
  }
}
