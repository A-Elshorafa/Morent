using Morent.Core.Entities;

namespace Morent.Core.Specifications.CarSpecs;

public class CarWithTypeSpec : Specification<Car>
{
  public CarWithTypeSpec(int carId)
  {
    Query
      .Where(x => x.CarId == carId)
      .Include(x => x.CarType);
  }
}
