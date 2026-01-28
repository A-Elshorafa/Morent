using Morent.Core.DTOs;
using Morent.UseCases.Features.Cars.Update;
using Morent.Web.Common;
using IMediator = MediatR.IMediator;

namespace Morent.Web.Features.Car.Update;

public class UpdateCarEndpoint : Endpoint<UpdateCarRequest, ApiResponse<CarInfoCardDto>>
{
  private readonly IMediator _mediator;

  public UpdateCarEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Put(UpdateCarRequest.Route);
    AllowAnonymous();
    Group<CarGroup>();
  }

  public override async Task<ApiResponse<CarInfoCardDto>> HandleAsync(UpdateCarRequest req, CancellationToken ct)
  {
    var result = await _mediator.Send(new UpdateCarCommand(req), ct);

    Response.Success = result.IsSuccess;
    Response.Message = result.IsSuccess ? "Updated successfully" : "Not found";
    Response.Data = result.Value;

    return Response;
  }
}
