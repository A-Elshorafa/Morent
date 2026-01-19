using Morent.UseCases.DTOs;
using Morent.UseCases.Features.Locations.Create;
using Morent.Web.Common;
using IMediator = MediatR.IMediator;

namespace Morent.Web.Features.Locations.Create;

public class CreateLocationEndpoint : Endpoint<CreateLocationRequest, ApiResponse<LocationDto>>
{
  private readonly IMediator _mediator;

  public CreateLocationEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Post(CreateLocationRequest.Route);
    AllowAnonymous();
    Group<LocationGroup>();
  }

  public override async Task<ApiResponse<LocationDto>> HandleAsync(CreateLocationRequest req, CancellationToken ct)
  {
    var result = await _mediator.Send(new CreateLocationCommand(req.Name), ct);

    Response.Success = result.IsSuccess;
    Response.Message = result.IsSuccess ? "Created successfully" : "Error creating";
    Response.Data = result.Value;

    return Response;
  }
}
