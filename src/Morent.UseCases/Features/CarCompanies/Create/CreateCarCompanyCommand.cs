using Morent.Core.DTOs;

namespace Morent.UseCases.Features.CarCompanies.Create;

public record CreateCarCompanyCommand(string CompanyName) : MediatR.IRequest<Result<CarCompanyDto>>;

