using Morent.Core.Entities;

namespace Morent.UseCases.Features.CarCompanies.Delete;

public sealed class DeleteCarCompanyHandler
  : MediatR.IRequestHandler<DeleteCarCompanyCommand, Result<bool>>
{
  private readonly IRepository<CarCompany> _repo;

  public DeleteCarCompanyHandler(IRepository<CarCompany> repo)
  {
    _repo = repo;
  }

  public async Task<Result<bool>> Handle(DeleteCarCompanyCommand request, CancellationToken ct)
  {
    var entity = await _repo.GetByIdAsync(request.CompanyId, ct);
    if (entity == null) return Result.NotFound("Car Company not found");

    await _repo.DeleteAsync(entity, ct);

    return Result.Success(true);
  }
}
