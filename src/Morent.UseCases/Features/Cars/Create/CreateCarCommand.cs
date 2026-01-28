using Morent.Core.DTOs;

namespace Morent.UseCases.Features.Cars.Create;

public record CreateCarCommand(CreateCarDto carDto) : MediatR.IRequest<Result<CarInfoCardDto>>;
