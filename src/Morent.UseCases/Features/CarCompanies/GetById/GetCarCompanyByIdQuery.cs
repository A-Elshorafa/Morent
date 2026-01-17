using Morent.UseCases.DTOs;

namespace Morent.UseCases.Features.CarCompanies.GetById;

public record GetCarCompanyByIdQuery(int CompanyId) : MediatR.IRequest<Result<CarCompanyDto>>;
