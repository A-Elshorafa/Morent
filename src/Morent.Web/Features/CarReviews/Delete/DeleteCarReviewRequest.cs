namespace Morent.Web.Features.CarReviews.Delete;

public class DeleteCarReviewRequest
{
  public const string Route = "{Id:int}";
  public int Id { get; set; }
}
