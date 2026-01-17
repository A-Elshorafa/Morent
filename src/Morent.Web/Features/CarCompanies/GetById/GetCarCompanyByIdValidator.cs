using FluentValidation;

namespace Morent.Web.Features.CarCompanies.Update;

public class GetCarCompanyByIdValidator : Validator<GetCarCompanyByIdRequest>
{
  public GetCarCompanyByIdValidator()
  {
    RuleFor(x => x.CompanyId).GreaterThan(0);
  }
}
