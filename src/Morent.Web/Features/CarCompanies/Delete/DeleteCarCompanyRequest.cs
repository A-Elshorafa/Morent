namespace Morent.Web.Features.CarCompanies.Delete;

public class DeleteCarCompanyRequest
{
  public const string Route = "{CompanyId:int}";

  public int CompanyId { get; set; }
}
