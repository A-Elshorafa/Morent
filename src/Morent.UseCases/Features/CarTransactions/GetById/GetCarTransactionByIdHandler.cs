using Morent.Core.DTOs;
using Morent.Core.Entities;

namespace Morent.UseCases.Features.CarTransactions.GetById;

public class GetCarTransactionByIdHandler : MediatR.IRequestHandler<GetCarTransactionByIdQuery, Result<CarTransactionDetailsDto>>
{
  private readonly IRepository<CarTransaction> _repo;

  public GetCarTransactionByIdHandler(IRepository<CarTransaction> repo)
  {
    _repo = repo;
  }

  public async Task<Result<CarTransactionDetailsDto>> Handle(GetCarTransactionByIdQuery request, CancellationToken ct)
  {
    var entity = await _repo.GetByIdAsync(request.Id, ct);
    if (entity == null) return Result.NotFound("CarTransaction not found");

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
