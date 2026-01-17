using Morent.UseCases.DTOs;

namespace Morent.UseCases.Features.Locations.GetById;

public record GetLocationByIdQuery(int Id) : MediatR.IRequest<Result<LocationDto>>;
