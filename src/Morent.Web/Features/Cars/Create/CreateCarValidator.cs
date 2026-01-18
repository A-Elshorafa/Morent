using FluentValidation;
namespace Morent.Web.Features.Car.Create;

public class CreateCarValidator : Validator<CreateCarRequest>
{
  public CreateCarValidator()
  {
    RuleFor(x => x.ModelName)
      .NotEmpty().WithMessage("Model name is required.")
      .MaximumLength(100);

    RuleFor(x => x.RentalPrice)
      .GreaterThan(0).WithMessage("Rental price must be greater than 0.");

    RuleFor(x => x.LicensePlate)
      .NotEmpty().WithMessage("License plate is required.")
      .MaximumLength(20);

    RuleFor(x => x.Description)
      .NotEmpty().WithMessage("Description is required.")
      .MaximumLength(500);

    RuleFor(x => x.Year)
      .InclusiveBetween(1990, DateTime.UtcNow.Year + 1)
      .WithMessage("Year is invalid.");

    RuleFor(x => x.Color)
      .NotEmpty().WithMessage("Color is required.")
      .MaximumLength(30);

    RuleFor(x => x.NoOfPassengers)
      .GreaterThan(0).WithMessage("Passengers count must be greater than 0.")
      .LessThanOrEqualTo(20);

    RuleFor(x => x.FuelCapacity)
      .GreaterThan(0).WithMessage("Fuel capacity must be greater than 0.");

    RuleFor(x => x.PhotoUrl)
      .NotEmpty().WithMessage("Photo URL is required.");

    RuleFor(x => x.CarTypeId)
      .GreaterThan(0).WithMessage("Car type is required.");

    RuleFor(x => x.OwnerId)
      .GreaterThan(0).WithMessage("Owner is required.");

    RuleFor(x => x.CompanyId)
      .GreaterThan(0).WithMessage("Company is required.");
  }
}
