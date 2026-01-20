using Morent.Core.Entities;

namespace Morent.Core.Specifications.AuthSpecs;

public sealed class UserByEmailSpec : Specification<User>, ISingleResultSpecification<User>
{
  public UserByEmailSpec(string email)
  {
    Query.Where(u => u.Email == email);
  }
}
