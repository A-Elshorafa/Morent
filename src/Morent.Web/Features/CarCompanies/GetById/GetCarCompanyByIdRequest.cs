namespace Morent.Web.Features.CarCompanies.Update;

public class GetCarCompanyByIdRequest
{
  public const string Route = "{CompanyId:int}";

  public int CompanyId { get; set; }
}
