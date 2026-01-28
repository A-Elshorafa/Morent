using Morent.Core.Entities;
using Morent.Core.DTOs;

namespace Morent.UseCases.Features.CarTypes.GetAll;

public sealed class GetCarTypesHandler : MediatR.IRequestHandler<GetCarTypesQuery, Result<IReadOnlyList<CarTypeDto>>>
{
  private readonly IReadRepository<CarType> _repo;

  public GetCarTypesHandler(IReadRepository<CarType> repo)
  {
    _repo = repo;
  }

  public async Task<Result<IReadOnlyList<CarTypeDto>>> Handle(GetCarTypesQuery request, CancellationToken ct)
  {
    var list = await _repo.ListAsync(ct);
    return list.Select(x => new CarTypeDto { CarTypeId = x.CarTypeId, TypeName = x.TypeName }).ToList();
  }
}
