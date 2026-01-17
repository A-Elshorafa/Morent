using Morent.UseCases.DTOs;
using Morent.UseCases.Features.Locations.GetAll;
using Morent.Web.Common;
using IMediator = MediatR.IMediator;

namespace Morent.Web.Features.Location.GetAll;

public class GetLocationAllEndpoint : EndpointWithoutRequest<ApiResponse<List<LocationDto>>>
{
  private readonly IMediator _mediator;

  public GetLocationAllEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Get("");
    AllowAnonymous();
    Group<LocationGroup>();
  }

  public override async Task<ApiResponse<List<LocationDto>>> HandleAsync(CancellationToken ct)
  {
    var result = await _mediator.Send(new GetLocationAllQuery(), ct);

    Response.Success = result.IsSuccess;
    Response.Message = "List fetched";
    Response.Data = result.Value;

    return Response;
  }
}
