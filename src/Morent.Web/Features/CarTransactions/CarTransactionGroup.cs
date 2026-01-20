using FastEndpoints;

namespace Morent.Web.Features.CarTransactions;

public class CarTransactionGroup : Group
{
  public CarTransactionGroup()
  {
    Configure("car-transactions", g => {});
  }
}
