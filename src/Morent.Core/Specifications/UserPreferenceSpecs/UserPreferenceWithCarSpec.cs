namespace Morent.Core.Specifications.UserPreferenceSpecs;

public class UserPreferenceWithCarSpec : Specification<Entities.UserPreference>
{
  public UserPreferenceWithCarSpec(int preferenceId)
  {
    Query
      .Where(x => x.UserPreferencesId == preferenceId)
      .Include(x => x.Car)
      .ThenInclude(c => c.CarType);
  }
  
  public UserPreferenceWithCarSpec()
  {
    Query
      .Include(x => x.Car)
      .ThenInclude(c => c.CarType);
  }
}
