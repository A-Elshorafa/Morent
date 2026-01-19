using FluentValidation;

namespace Morent.Web.Features.CarTransactions.Update;

public class UpdateCarTransactionValidator : Validator<UpdateCarTransactionRequest>
{
  public UpdateCarTransactionValidator()
  {
    RuleFor(x => x.CarTransactionId)
      .GreaterThan(0).WithMessage("Car Transaction ID is required.");
    
    RuleFor(x => x.FromDate)
      .NotEmpty().WithMessage("From date is required.");

    RuleFor(x => x.ToDate)
      .NotEmpty().WithMessage("To date is required.")
      .GreaterThan(x => x.FromDate)
      .WithMessage("To date must be after From date.");

    RuleFor(x => x.PickupLocationId)
      .GreaterThan(0).WithMessage("Pickup location is required.");

    RuleFor(x => x.DropOfLocationId)
      .GreaterThan(0).WithMessage("Drop-off location is required.");
  }
}
