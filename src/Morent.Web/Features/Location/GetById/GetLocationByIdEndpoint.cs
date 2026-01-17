using Morent.UseCases.DTOs;
using Morent.UseCases.Features.Locations.GetById;
using Morent.Web.Common;
using IMediator = MediatR.IMediator;

namespace Morent.Web.Features.Location.GetById;

public class GetLocationByIdEndpoint : Endpoint<GetLocationByIdRequest, ApiResponse<LocationDto>>
{
  private readonly IMediator _mediator;

  public GetLocationByIdEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Get(GetLocationByIdRequest.Route);
    AllowAnonymous();
    Group<LocationGroup>();
  }

  public override async Task<ApiResponse<LocationDto>> HandleAsync(GetLocationByIdRequest req, CancellationToken ct)
  {
    var result = await _mediator.Send(new GetLocationByIdQuery(req.Id), ct);

    Response.Success = result.IsSuccess;
    Response.Message = result.IsSuccess ? "Fetched successfully" : "Not found";
    Response.Data = result.Value;

    return Response;
  }
}
