using Morent.Core.Entities;

namespace Morent.Core.Specifications.CarSpecs;

public class CarsListSpec: Specification<Car>
{
  public CarsListSpec(int pageNumber = 1, int pageSize = 10, string? searchKey = null)
  {
    if (!string.IsNullOrEmpty(searchKey))
    {
      var searchToken = searchKey.ToLower();
      Query
        .Include(s => s.CarType)
        .Include(s => s.Company)
        .Where(s =>
          s.ModelName.ToLower().Contains(searchToken) ||
          s.CarType.TypeName.ToLower().Contains(searchToken) ||
          s.Company.CompanyName.ToLower().Contains(searchToken)
        );
    }
    else
    {
      Query.Include(s => s.CarType);
    }
    Query.Take(pageSize).Skip((pageNumber - 1) * pageSize);
  }
}
