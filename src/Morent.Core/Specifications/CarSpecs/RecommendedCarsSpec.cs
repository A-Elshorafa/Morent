using Morent.Core.Entities;

namespace Morent.Core.Specifications.CarSpecs;

public class RecommendedCarsSpec: Specification<Car>
{
  public RecommendedCarsSpec(int pageIndex, int pageSize)
  {
    Query
      .Where(c => c.IsAvailable && c.IsPopular)
      .Include(c => c.CarType)
      .Include(c => c.Company)
      .OrderByDescending(c => c.CreatedAt)
      .Skip(pageIndex * pageSize)
      .Take(pageSize);
  }
}
