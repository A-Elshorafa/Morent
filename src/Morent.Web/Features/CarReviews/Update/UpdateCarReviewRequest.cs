using Morent.UseCases.DTOs;

namespace Morent.Web.Features.CarReviews.Update;

public class UpdateCarReviewRequest : UpdateCarReviewDto
{
  public const string Route = "{Id:int}";
}
