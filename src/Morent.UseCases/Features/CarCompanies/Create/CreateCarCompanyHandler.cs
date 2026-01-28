using Morent.Core.Entities;
using Morent.Core.DTOs;

namespace Morent.UseCases.Features.CarCompanies.Create;

public sealed class CreateCarCompanyHandler
  : MediatR.IRequestHandler<CreateCarCompanyCommand, Result<CarCompanyDto>>
{
  private readonly IRepository<CarCompany> _repo;

  public CreateCarCompanyHandler(IRepository<CarCompany> repo)
  {
    _repo = repo;
  }

  public async Task<Result<CarCompanyDto>> Handle(CreateCarCompanyCommand request, CancellationToken ct)
  {
    var entity = new CarCompany
    {
      CompanyName = request.CompanyName
    };

    await _repo.AddAsync(entity, ct);

    return Result.Success(new CarCompanyDto(entity.CompanyId, entity.CompanyName));
  }
}
