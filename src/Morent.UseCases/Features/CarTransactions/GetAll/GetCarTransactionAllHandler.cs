using Morent.Core.DTOs;
using Morent.Core.Entities;

namespace Morent.UseCases.Features.CarTransactions.GetAll;

public class GetCarTransactionAllHandler : MediatR.IRequestHandler<GetCarTransactionAllQuery, Result<List<CarTransactionDetailsDto>>>
{
  private readonly IRepository<CarTransaction> _repo;

  public GetCarTransactionAllHandler(IRepository<CarTransaction> repo)
  {
    _repo = repo;
  }

  public async Task<Result<List<CarTransactionDetailsDto>>> Handle(GetCarTransactionAllQuery request, CancellationToken ct)
  {
    var list = await _repo.ListAsync(ct);

    return Result.Success(list
      .Select(entity => new CarTransactionDetailsDto(
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
      ))
      .ToList());
  }
}
