using Morent.UseCases.DTOs;
using Morent.Core.Entities;

namespace Morent.UseCases.Features.CarTransactions.Create;

public class CreateCarTransactionHandler : MediatR.IRequestHandler<CreateCarTransactionCommand, Result<CarTransactionDetailsDto>>
{
  private readonly IRepository<CarTransaction> _repo;

  public CreateCarTransactionHandler(IRepository<CarTransaction> repo)
  {
    _repo = repo;
  }

  public async Task<Result<CarTransactionDetailsDto>> Handle(CreateCarTransactionCommand request, CancellationToken ct)
  {
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

    await _repo.AddAsync(entity, ct);

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
