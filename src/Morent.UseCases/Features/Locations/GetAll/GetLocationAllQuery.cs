using Morent.Core.DTOs;

namespace Morent.UseCases.Features.Locations.GetAll;

public record GetLocationAllQuery() : MediatR.IRequest<Result<List<LocationDto>>>;
