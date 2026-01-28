using Morent.Core.DTOs;

namespace Morent.UseCases.Features.Cars.GetById;

public record GetCarByIdQuery(int Id) : MediatR.IRequest<Result<CarInfoCardDto>>;
