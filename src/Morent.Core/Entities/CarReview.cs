using System.ComponentModel.DataAnnotations;
using Morent.Core.Common;
namespace Morent.Core.Entities;

public class CarReview : FullAuditedEntity
{   
  [Key]
  public int CarReviewId { get; set; }
  public int CarId { get; set; }
  public virtual Car Car { get; set; } = null!;
  public int UserId { get; set; }
  public virtual User User { get; set; } = null!;
  public int Rating { get; set; }
  public string ReviewText { get; set; } = null!;
}
