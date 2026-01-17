using Morent.UseCases.DTOs;

namespace Morent.UseCases.Features.Locations.Update;

public record UpdateLocationCommand(int Id, string Name) : MediatR.IRequest<Result<LocationDto>>;
