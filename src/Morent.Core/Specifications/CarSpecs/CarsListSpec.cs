using System.Runtime.InteropServices.JavaScript;
using Morent.Core.Entities;
using Morent.Core.Specifications.Rules.Cars;
using Morent.Core.DTOs;

namespace Morent.Core.Specifications.CarSpecs;

public class CarsListSpec: Specification<Car>
{
  public CarsListSpec(CarListDto req)
  {
    Query.Include(s => s.CarType);

    if (!string.IsNullOrEmpty(req.SearchToken))
    {
      var searchToken = req.SearchToken.ToLower();
      Query
        .Include(s => s.Company)
        .Where(s =>
          s.ModelName.ToLower().Contains(searchToken) ||
          s.CarType.TypeName.ToLower().Contains(searchToken) ||
          s.Company.CompanyName.ToLower().Contains(searchToken)
        );
    }
    if (req.FromDate != null || req.ToDate != null)
    {
      Query.Include(c => c.Transactions)
        .Where(CarAvailabilityRule.IsAvailable(
          req.FromDate,
          req.ToDate));
    }

    if (req.LocationId != null)
    {
      Query.Where(c => c.LocationId == req.LocationId);
    }

    Query.Take(req.PageSize).Skip((req.PageNumber - 1) * req.PageSize);
  }
}
