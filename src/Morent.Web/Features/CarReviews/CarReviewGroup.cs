using FastEndpoints;

namespace Morent.Web.Features.CarReviews;

public class CarReviewGroup : Group
{
  public CarReviewGroup()
  {
    Configure("car-reviews", g => { });
  }
}
