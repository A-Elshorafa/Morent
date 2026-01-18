using Morent.UseCases.DTOs;
using Morent.Core.Entities;

namespace Morent.UseCases.Features.CarTransactions.Update;

public class UpdateCarTransactionHandler : MediatR.IRequestHandler<UpdateCarTransactionCommand, Result<CarTransactionDetailsDto>>
{
  private readonly IRepository<CarTransaction> _repo;

  public UpdateCarTransactionHandler(IRepository<CarTransaction> repo)
  {
    _repo = repo;
  }

  public async Task<Result<CarTransactionDetailsDto>> Handle(UpdateCarTransactionCommand request, CancellationToken ct)
  {
    var entity = await _repo.GetByIdAsync((int)request.reqDto.CarTransactionId!, ct);
    if (entity == null) return Result.NotFound("CarTransaction not found");

    if(request.reqDto.ToDate != entity.ToDate) entity.ToDate = request.reqDto.ToDate;
    if(request.reqDto.FromDate != entity.FromDate) entity.FromDate = request.reqDto.FromDate;
    if(request.reqDto.DropOfLocationId != entity.DropOfLocationId) entity.DropOfLocationId = request.reqDto.DropOfLocationId;
    if(request.reqDto.PickupLocationId != entity.PickupLocationId) entity.PickupLocationId = request.reqDto.PickupLocationId;

    await _repo.UpdateAsync(entity, ct);

    return Result.Success(new CarTransactionDetailsDto(
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
    ));
  }
}
