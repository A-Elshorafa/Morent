namespace Morent.Web.Features.CarReviews.GetById;

public class GetCarReviewByIdRequest
{
  public const string Route = "/api/carreview/{Id:int}";
  public int Id { get; set; }
}
