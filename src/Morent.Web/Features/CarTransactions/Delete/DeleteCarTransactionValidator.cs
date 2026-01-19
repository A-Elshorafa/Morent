using FluentValidation;

namespace Morent.Web.Features.CarTransactions.Delete;

public class DeleteCarTransactionValidator : Validator<DeleteCarTransactionRequest>
{
  public DeleteCarTransactionValidator()
  {
    RuleFor(x => x.Id).GreaterThan(0);
  }
}
