namespace Morent.Web.Features.CarTransactions.GetById;

public class GetCarTransactionByIdRequest
{
  public const string Route = "{Id:int}";
  public int Id { get; set; }
}
