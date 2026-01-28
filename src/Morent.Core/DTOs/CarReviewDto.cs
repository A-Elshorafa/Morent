namespace Morent.Core.DTOs;

public class CreateCarReviewDto
{
  public int? CarId { get; set; }
  public int? UserId { get; set; }
  public int? Rating { get; set; }
  public string? ReviewText { get; set; } = null!;
  
  public CreateCarReviewDto(int? carId = null, int? userId= null, int? rating= null, string? reviewText= null)
  {
    CarId = carId;
    UserId = userId;
    Rating = rating;
    ReviewText = reviewText;
  }
}

public class UpdateCarReviewDto : CreateCarReviewDto
{
  public int? CarReviewId { get; set; }

  public UpdateCarReviewDto(int? carId = null, int? userId= null, int? rating= null, string? reviewText= null, int? carReviewId= null) 
  {
    CarId = carId;
    UserId = userId;
    Rating = rating;
    ReviewText = reviewText;
    CarReviewId = carReviewId;
  }
}

public class GetCarReviewDto : UpdateCarReviewDto
{
  public GetCarReviewDto(int carId, int userId, int rating, string reviewText, int carReviewId) : base(carId, userId, rating, reviewText, carReviewId)
  {
    CarId = carId;
    UserId = userId;
    Rating = rating;
    ReviewText = reviewText;
    CarReviewId = carReviewId;
  }
}
