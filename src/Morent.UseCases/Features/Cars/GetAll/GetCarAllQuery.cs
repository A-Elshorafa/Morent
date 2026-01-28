using Morent.Core.DTOs;

namespace Morent.UseCases.Features.Cars.GetAll;

public record GetCarAllQuery(CarListDto carListDto) : MediatR.IRequest<Result<List<CarInfoCardDto>>>;
