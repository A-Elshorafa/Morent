namespace Morent.Web.Features.CarCompanies.Update;

public class UpdateCarCompanyRequest
{
  public const string Route = "/{CompanyId:int}";

  public int CompanyId { get; set; }
  public string CompanyName { get; set; } = "";
}
