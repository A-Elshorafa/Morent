using Morent.UseCases.DTOs;
using Morent.UseCases.Features.Cars.Create;
using Morent.Web.Common;
using IMediator = MediatR.IMediator;

namespace Morent.Web.Features.Car.Create;

public class CreateCarEndpoint : Endpoint<CreateCarRequest, ApiResponse<CarInfoCardDto>>
{
  private readonly IMediator _mediator;

  public CreateCarEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Post(CreateCarRequest.Route);
    AllowAnonymous();
    Group<CarGroup>();
  }

  public override async Task<ApiResponse<CarInfoCardDto>> HandleAsync(CreateCarRequest req, CancellationToken ct)
  {
    var result = await _mediator.Send(new CreateCarCommand(req), ct);

    Response.Success = result.IsSuccess;
    Response.Message = result.IsSuccess ? "Created successfully" : "Error creating";
    Response.Data = result.Value;

    return Response;
  }
}
