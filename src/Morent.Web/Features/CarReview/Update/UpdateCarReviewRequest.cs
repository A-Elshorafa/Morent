using Morent.UseCases.DTOs;

namespace Morent.Web.Features.CarReview.Update;

public class UpdateCarReviewRequest : UpdateCarReviewDto
{
  public const string Route = "{Id:int}";
}
