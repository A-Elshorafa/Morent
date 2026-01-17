using Morent.Core.Entities;
using Morent.UseCases.DTOs;

namespace Morent.UseCases.Features.CarCompanies.GetAll;

public sealed class GetCarCompanyListHandler
  : MediatR.IRequestHandler<GetCarCompanyListQuery, Result<List<CarCompanyDto>>>
{
  private readonly IRepository<CarCompany> _repo;

  public GetCarCompanyListHandler(IRepository<CarCompany> repo)
  {
    _repo = repo;
  }

  public async Task<Result<List<CarCompanyDto>>> Handle(GetCarCompanyListQuery request, CancellationToken ct)
  {
    var list = await _repo.ListAsync(ct);

    return Result.Success(list
      .Select(x => new CarCompanyDto(x.CompanyId, x.CompanyName))
      .ToList());
  }
}

