namespace Morent.Web.Features.CarTransaction.GetById;

public class GetCarTransactionByIdRequest
{
  public const string Route = "{Id:int}";
  public int Id { get; set; }
}
