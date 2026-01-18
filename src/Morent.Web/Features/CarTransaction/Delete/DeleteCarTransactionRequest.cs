namespace Morent.Web.Features.CarTransaction.Delete;

public class DeleteCarTransactionRequest
{
  public const string Route = "{Id:int}";
  public int Id { get; set; }
}
