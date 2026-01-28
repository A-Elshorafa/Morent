using System.Threading;
using System.Threading.Tasks;
using Morent.Core.DTOs;
using Morent.Core.Entities;

namespace Morent.UseCases.Features.CarTransactions.Create;

public class CreateCarTransactionHandler : MediatR.IRequestHandler<CreateCarTransactionCommand, Result<CarTransactionDetailsDto>>
{
  private readonly IRepository<Car> _carRepo;
  private readonly IRepository<User> _userRepo;
  private readonly IRepository<Location> _locationRepo;
  private readonly IRepository<CarTransaction> _transactionRepo;

  public CreateCarTransactionHandler(
    IRepository<CarTransaction> transactionRepo,
    IRepository<Car> carRepo,
    IRepository<User> userRepo,
    IRepository<Location> locationRepo)
  {
    _transactionRepo = transactionRepo;
    _carRepo = carRepo;
    _userRepo = userRepo;
    _locationRepo = locationRepo;
  }

  public async Task<Result<CarTransactionDetailsDto>> Handle(CreateCarTransactionCommand request, CancellationToken ct)
  {
    var carExists = await _carRepo.GetByIdAsync(request.reqDto.CarId, ct);
    if (carExists is null)
      return Result.NotFound($"Car with id {request.reqDto.CarId} was not found.");

    // ✅ Renter (User) check
    var renterExists = await _userRepo.GetByIdAsync(request.reqDto.RenterId, ct);
    if (renterExists is null)
      return Result.NotFound($"User with id {request.reqDto.RenterId} was not found.");

    // ✅ Pickup location check
    var pickupExists = await _locationRepo.GetByIdAsync(request.reqDto.PickupLocationId, ct);
    if (pickupExists is null)
      return Result.NotFound($"Pickup location with id {request.reqDto.PickupLocationId} was not found.");

    // ✅ Drop-off location check
    var dropOffExists = await _locationRepo.GetByIdAsync(request.reqDto.DropOfLocationId, ct);
    if (dropOffExists is null)
      return Result.NotFound($"Drop-off location with id {request.reqDto.DropOfLocationId} was not found.");
    
    var entity = new CarTransaction
    {
      CarId = request.reqDto.CarId,
      RentalPrice = request.reqDto.RentalPrice,
      CardExpiryDate =  request.reqDto.CardExpiryDate,
      CardNumber = request.reqDto.CardNumber,
      CardHolderName = request.reqDto.CardHolderName,
      RenterId = request.reqDto.RenterId,
      SubTotal = request.reqDto.SubTotal,
      FromDate = request.reqDto.FromDate,
      ToDate = request.reqDto.ToDate,
      PromoCode = request.reqDto.PromoCode,
      PickupLocationId = request.reqDto.PickupLocationId,
      DropOfLocationId = request.reqDto.DropOfLocationId
    };

    await _transactionRepo.AddAsync(entity, ct);

    return Result.Success(
      new CarTransactionDetailsDto(
        entity.CarTransactionId,
        entity.FromDate,
        entity.ToDate,
        entity.RentalPrice,
        entity.CardNumber,
        entity.CardHolderName,
        entity.CardExpiryDate,
        entity.PromoCode,
        entity.SubTotal,
        entity.CarId,
        entity.RenterId,
        entity.PickupLocationId,
        entity.DropOfLocationId,
        entity.CreatedAt,
        entity.UpdatedAt
      )
    );
  }
}
