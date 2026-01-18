namespace Morent.Web.Features.CarReview.Delete;

public class DeleteCarReviewRequest
{
  public const string Route = "{Id:int}";
  public int Id { get; set; }
}
