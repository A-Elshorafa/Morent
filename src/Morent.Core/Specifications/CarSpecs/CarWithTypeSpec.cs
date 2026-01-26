using Morent.Core.Entities;

namespace Morent.Core.Specifications.CarSpecs;

public class CarWithTypeSpec : Specification<Car>
{
  public CarWithTypeSpec(int?  carId = null)
  {
    if (carId.HasValue)
    {
      Query
        .Where(x => x.CarId == carId)
        .Include(x => x.CarType);
    }
    
    Query.Include(x => x.CarType);
  }
}
