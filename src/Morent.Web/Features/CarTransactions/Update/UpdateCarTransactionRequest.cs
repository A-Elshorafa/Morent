using Morent.Core.DTOs;

namespace Morent.Web.Features.CarTransactions.Update;

public class UpdateCarTransactionRequest : UpdateCarTransactionDto
{
  public const string Route = "{Id:int}";
}
