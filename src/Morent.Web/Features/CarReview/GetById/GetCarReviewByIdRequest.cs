namespace Morent.Web.Features.CarReview.GetById;

public class GetCarReviewByIdRequest
{
  public const string Route = "/api/carreview/{Id:int}";
  public int Id { get; set; }
}
