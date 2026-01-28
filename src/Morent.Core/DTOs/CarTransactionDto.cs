namespace Morent.Core.DTOs;

public abstract class CarTransactionBaseDto
{
  public DateTime FromDate { get; set; }
  public DateTime ToDate { get; set; }
  public decimal RentalPrice { get; set; }

  public string? CardNumber { get; set; }
  public string? CardHolderName { get; set; }
  public DateTime CardExpiryDate { get; set; }

  public string? PromoCode { get; set; }
  public string? SubTotal { get; set; }

  public int CarId { get; set; }
  public int RenterId { get; set; }
  public int PickupLocationId { get; set; }
  public int DropOfLocationId { get; set; }
  
  public CarTransactionBaseDto(
    DateTime? fromDate = null,
    DateTime? toDate = null,
    decimal? rentalPrice = null,
    string? cardNumber = null,
    string? cardHolderName = null,
    DateTime? cardExpiryDate = null,
    string? promoCode = null,
    string? subTotal = null,
    int? carId = null,
    int? renterId = null,
    int? pickupLocationId = null,
    int? dropOfLocationId = null)
  {
    if (fromDate.HasValue) FromDate = fromDate.Value;
    if (toDate.HasValue) ToDate = toDate.Value;
    if (rentalPrice.HasValue) RentalPrice = rentalPrice.Value;

    CardNumber = cardNumber;
    CardHolderName = cardHolderName;
    if (cardExpiryDate.HasValue) CardExpiryDate = cardExpiryDate.Value;

    PromoCode = promoCode;
    SubTotal = subTotal;

    if (carId.HasValue) CarId = carId.Value;
    if (renterId.HasValue) RenterId = renterId.Value;
    if (pickupLocationId.HasValue) PickupLocationId = pickupLocationId.Value;
    if (dropOfLocationId.HasValue) DropOfLocationId = dropOfLocationId.Value;
  }
}

public class CreateCarTransactionDto : CarTransactionBaseDto
{
  public CreateCarTransactionDto(
    DateTime? fromDate = null,
    DateTime? toDate = null,
    decimal? rentalPrice = null,
    string? cardNumber = null,
    string? cardHolderName = null,
    DateTime? cardExpiryDate = null,
    string? promoCode = null,
    string? subTotal = null,
    int? carId = null,
    int? renterId = null,
    int? pickupLocationId = null,
    int? dropOfLocationId = null)
  {
    if (fromDate.HasValue) FromDate = fromDate.Value;
    if (toDate.HasValue) ToDate = toDate.Value;
    if (rentalPrice.HasValue) RentalPrice = rentalPrice.Value;

    CardNumber = cardNumber;
    CardHolderName = cardHolderName;
    if (cardExpiryDate.HasValue) CardExpiryDate = cardExpiryDate.Value;

    PromoCode = promoCode;
    SubTotal = subTotal;

    if (carId.HasValue) CarId = carId.Value;
    if (renterId.HasValue) RenterId = renterId.Value;
    if (pickupLocationId.HasValue) PickupLocationId = pickupLocationId.Value;
    if (dropOfLocationId.HasValue) DropOfLocationId = dropOfLocationId.Value;
  }
}

public class UpdateCarTransactionDto
{
  public int? CarTransactionId { get; set; }
  public DateTime FromDate { get; set; }
  public DateTime ToDate { get; set; }
  public int PickupLocationId { get; set; }
  public int DropOfLocationId { get; set; }
  
  public UpdateCarTransactionDto(
    int? carTransactionId = null,
    DateTime? fromDate = null,
    DateTime? toDate = null,
    int? pickupLocationId = null,
    int? dropOfLocationId = null)
  {
    CarTransactionId = carTransactionId;
    if (fromDate.HasValue) FromDate = fromDate.Value;
    if (toDate.HasValue) ToDate = toDate.Value;

    if (pickupLocationId.HasValue) PickupLocationId = pickupLocationId.Value;
    if (dropOfLocationId.HasValue) DropOfLocationId = dropOfLocationId.Value;
  }
}


public class CarTransactionDetailsDto : CarTransactionBaseDto
{
  public int? CarTransactionId { get; set; }

  public DateTime CreatedAt { get; set; }
  public DateTime? LastModifiedAt { get; set; }
  
  public CarTransactionDetailsDto(
    int? carTransactionId = null,
    DateTime? fromDate = null,
    DateTime? toDate = null,
    decimal? rentalPrice = null,
    string? cardNumber = null,
    string? cardHolderName = null,
    DateTime? cardExpiryDate = null,
    string? promoCode = null,
    string? subTotal = null,
    int? carId = null,
    int? renterId = null,
    int? pickupLocationId = null,
    int? dropOfLocationId = null,
    DateTime? createdAt = null,
    DateTime? lastModifiedAt = null
  )
  {
    CarTransactionId = carTransactionId;
    if (fromDate.HasValue) FromDate = fromDate.Value;
    if (toDate.HasValue) ToDate = toDate.Value;
    if (rentalPrice.HasValue) RentalPrice = rentalPrice.Value;

    CardNumber = cardNumber;
    CardHolderName = cardHolderName;
    if (cardExpiryDate.HasValue) CardExpiryDate = cardExpiryDate.Value;

    PromoCode = promoCode;
    SubTotal = subTotal;

    if (carId.HasValue) CarId = carId.Value;
    if (renterId.HasValue) RenterId = renterId.Value;
    if (pickupLocationId.HasValue) PickupLocationId = pickupLocationId.Value;
    if (dropOfLocationId.HasValue) DropOfLocationId = dropOfLocationId.Value;
    if (createdAt.HasValue) CreatedAt = createdAt.Value;
    if (lastModifiedAt.HasValue) LastModifiedAt = lastModifiedAt.Value;
  }
}

public class DeleteCarTransactionDto
{
  public int CarTransactionId { get; set; }
}
