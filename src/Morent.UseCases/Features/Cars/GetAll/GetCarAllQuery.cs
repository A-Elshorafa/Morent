using Morent.UseCases.DTOs;

namespace Morent.UseCases.Features.Cars.GetAll;

public record GetCarAllQuery(int pageSize = 10, int pageNumber = 1, string? searchToken = null) : MediatR.IRequest<Result<List<CarInfoCardDto>>>;
