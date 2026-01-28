using Morent.Core.DTOs;

namespace Morent.UseCases.Features.Locations.Create;

public record CreateLocationCommand(string Name) : MediatR.IRequest<Result<LocationDto>>;
