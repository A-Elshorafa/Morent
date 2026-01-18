using Morent.UseCases.DTOs;
using Morent.UseCases.Features.Cars.GetById;
using Morent.Web.Common;
using IMediator = MediatR.IMediator;

namespace Morent.Web.Features.Car.GetById;

public class GetCarByIdEndpoint : Endpoint<GetCarByIdRequest, ApiResponse<CarInfoCardDto>>
{
  private readonly IMediator _mediator;

  public GetCarByIdEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Get(GetCarByIdRequest.Route);
    AllowAnonymous();
    Group<CarGroup>();
  }

  public override async Task<ApiResponse<CarInfoCardDto>> HandleAsync(GetCarByIdRequest req, CancellationToken ct)
  {
    var result = await _mediator.Send(new GetCarByIdQuery(req.Id), ct);

    Response.Success = result.IsSuccess;
    Response.Message = result.IsSuccess ? "Fetched successfully" : "Not found";
    Response.Data = result.Value;

    return Response;
  }
}
