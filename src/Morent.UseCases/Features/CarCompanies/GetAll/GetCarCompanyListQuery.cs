using Morent.UseCases.DTOs;

namespace Morent.UseCases.Features.CarCompanies.GetAll;

public record GetCarCompanyListQuery() : MediatR.IRequest<Result<List<CarCompanyDto>>>;
