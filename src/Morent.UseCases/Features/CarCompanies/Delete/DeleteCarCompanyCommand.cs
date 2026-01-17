namespace Morent.UseCases.Features.CarCompanies.Delete;

public record DeleteCarCompanyCommand(int CompanyId) : MediatR.IRequest<Result<bool>>;

