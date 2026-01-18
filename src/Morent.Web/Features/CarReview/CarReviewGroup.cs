using FastEndpoints;

namespace Morent.Web.Features.CarReview;

public class CarReviewGroup : Group
{
  public CarReviewGroup()
  {
    Configure("car-review", g => g.AllowAnonymous());
  }
}
