using Morent.Core.DTOs;
using Morent.UseCases.Features.Locations.Update;
using Morent.Web.Common;
using IMediator = MediatR.IMediator;

namespace Morent.Web.Features.Locations.Update;

public class UpdateLocationEndpoint : Endpoint<UpdateLocationRequest, ApiResponse<LocationDto>>
{
  private readonly IMediator _mediator;

  public UpdateLocationEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Put(UpdateLocationRequest.Route);
    AllowAnonymous();
    Group<LocationGroup>();
  }

  public override async Task<ApiResponse<LocationDto>> HandleAsync(UpdateLocationRequest req, CancellationToken ct)
  {
    var result = await _mediator.Send(new UpdateLocationCommand(req.Id, req.Name), ct);

    Response.Success = result.IsSuccess;
    Response.Message = result.IsSuccess ? "Updated successfully" : "Not found";
    Response.Data = result.Value;

    return Response;
  }
}
