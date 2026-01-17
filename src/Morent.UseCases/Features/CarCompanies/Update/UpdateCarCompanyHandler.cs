using Morent.Core.Entities;
using Morent.UseCases.DTOs;

namespace Morent.UseCases.Features.CarCompanies.Update;

public sealed class UpdateCarCompanyHandler
  : MediatR.IRequestHandler<UpdateCarCompanyCommand, Result<CarCompanyDto>>
{
  private readonly IRepository<CarCompany> _repo;

  public UpdateCarCompanyHandler(IRepository<CarCompany> repo)
  {
    _repo = repo;
  }

  public async Task<Result<CarCompanyDto>> Handle(UpdateCarCompanyCommand request, CancellationToken ct)
  {
    var entity = await _repo.GetByIdAsync(request.CompanyId, ct);
    if (entity == null) return Result.NotFound("Car Company not found");

    entity.CompanyName = request.CompanyName;

    await _repo.UpdateAsync(entity, ct);

    return Result.Success(new CarCompanyDto(entity.CompanyId, entity.CompanyName));
  }
}

