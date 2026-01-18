using Morent.UseCases.DTOs;

namespace Morent.UseCases.Features.Cars.GetAll;

public record GetCarAllQuery() : MediatR.IRequest<Result<List<CarInfoCardDto>>>;
