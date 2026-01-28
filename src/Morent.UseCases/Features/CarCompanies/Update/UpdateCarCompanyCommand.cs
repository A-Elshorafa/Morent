using Morent.Core.DTOs;

namespace Morent.UseCases.Features.CarCompanies.Update;

public record UpdateCarCompanyCommand(int CompanyId, string CompanyName)
  : MediatR.IRequest<Result<CarCompanyDto>>;

