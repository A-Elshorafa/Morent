using Morent.UseCases.DTOs;

namespace Morent.Web.Features.CarTransaction.Update;

public class UpdateCarTransactionRequest : UpdateCarTransactionDto
{
  public const string Route = "{Id:int}";
}
