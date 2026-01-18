using Morent.UseCases.DTOs;
using Morent.UseCases.Features.Cars.GetAll;
using Morent.Web.Common;
using IMediator = MediatR.IMediator;

namespace Morent.Web.Features.Car.GetAll;

public class GetCarAllEndpoint : EndpointWithoutRequest<ApiResponse<List<CarInfoCardDto>>>
{
  private readonly IMediator _mediator;

  public GetCarAllEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Get("");
    AllowAnonymous();
    Group<CarGroup>();
  }

  public override async Task<ApiResponse<List<CarInfoCardDto>>> HandleAsync(CancellationToken ct)
  {
    var result = await _mediator.Send(new GetCarAllQuery(), ct);

    Response.Success = result.IsSuccess;
    Response.Message = "List fetched";
    Response.Data = result.Value;

    return Response;
  }
}
