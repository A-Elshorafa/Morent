using FastEndpoints;

namespace Morent.Web.Features.CarTransaction;

public class CarTransactionGroup : Group
{
  public CarTransactionGroup()
  {
    Configure("car-transaction", g => g.AllowAnonymous());
  }
}
