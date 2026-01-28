using Morent.Core.Entities;
using Morent.Core.DTOs;

namespace Morent.UseCases.Features.CarCompanies.GetById;

public sealed class GetCarCompanyByIdHandler
  : MediatR.IRequestHandler<GetCarCompanyByIdQuery, Result<CarCompanyDto>>
{
  private readonly IRepository<CarCompany> _repo;

  public GetCarCompanyByIdHandler(IRepository<CarCompany> repo)
  {
    _repo = repo;
  }

  public async Task<Result<CarCompanyDto>> Handle(GetCarCompanyByIdQuery request, CancellationToken ct)
  {
    var entity = await _repo.GetByIdAsync(request.CompanyId, ct);
    if (entity == null) return Result.NotFound("Car Company not found");

    return Result.Success(new CarCompanyDto(entity.CompanyId, entity.CompanyName));
  }
}

