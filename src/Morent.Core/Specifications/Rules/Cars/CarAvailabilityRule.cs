using System.Linq.Expressions;
using Morent.Core.Entities;

namespace Morent.Core.Specifications.Rules.Cars;

public class CarAvailabilityRule
{
  public static Expression<Func<Car, bool>> IsAvailable(
    DateTime? from,
    DateTime? to)
  {
    if (!from.HasValue && !to.HasValue)
      return c => true;

    return c =>
      !c.Transactions.Any(t =>
        (from.HasValue && to.HasValue &&
         t.FromDate < to && t.ToDate > from)
        ||
        (from.HasValue && !to.HasValue &&
         t.ToDate > from)
        ||
        (!from.HasValue && to.HasValue &&
         t.FromDate < to)
      );
  }
}
