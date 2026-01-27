using FluentValidation;
namespace Morent.Web.Features.CarTransactions.Create;

public class CreateCarTransactionValidator : Validator<CreateCarTransactionRequest>
{
  public CreateCarTransactionValidator()
  {
    RuleFor(x => x.FromDate)
      .NotEmpty().WithMessage("From date is required.");

    RuleFor(x => x.ToDate)
      .NotEmpty().WithMessage("To date is required.")
      .GreaterThan(x => x.FromDate)
      .WithMessage("To date must be after From date.");

    RuleFor(x => x.RentalPrice)
      .GreaterThan(0).WithMessage("Rental price must be greater than 0.");

    RuleFor(x => x.CardNumber)
      .NotEmpty().WithMessage("Card number is required.");

    RuleFor(x => x.CardHolderName)
      .MaximumLength(100);

    RuleFor(x => x.CardExpiryDate)
      .GreaterThan(DateTime.UtcNow)
      .WithMessage("Card expiry date must be in the future.");

    RuleFor(x => x.PromoCode)
      .MaximumLength(50);

    RuleFor(x => x.SubTotal)
      .MaximumLength(50);

    RuleFor(x => x.CarId)
      .GreaterThan(0).WithMessage("CarId is required.");

    RuleFor(x => x.RenterId)
      .GreaterThan(0).WithMessage("RenterId is required.");

    RuleFor(x => x.PickupLocationId)
      .GreaterThan(0).WithMessage("Pickup location is required.");

    RuleFor(x => x.DropOfLocationId)
      .GreaterThan(0).WithMessage("Drop-off location is required.");

  }
}
