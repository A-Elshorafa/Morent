using Morent.Core.DTOs;

namespace Morent.UseCases.Features.Cars.Update;

public record UpdateCarCommand(UpdateCarDto carDto) : MediatR.IRequest<Result<CarInfoCardDto>>;
