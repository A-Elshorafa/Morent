using Morent.UseCases.DTOs;
using Morent.UseCases.Features.Cars.GetRecommendedCars;
using Morent.Web.Common;
using IMediator = MediatR.IMediator;

namespace Morent.Web.Endpoints.Cars;

public sealed class GetRecommendedCarsEndpoint
  : Endpoint<GetRecommendedCarsRequest, ApiResponse<IReadOnlyList<CarInfoCardDto>>>
{
  private readonly IMediator _mediator;

  public GetRecommendedCarsEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Get(GetRecommendedCarsRequest.Route);
    AllowAnonymous();

    Summary(s =>
    {
      s.Summary = "List recommended cars";
      s.Description = "Returns recommended cars by reviews with pagination";
      s.ExampleRequest = new GetRecommendedCarsRequest
      {
        PageIndex = 1,
        PageSize = 10
      };
    });
  }

  public override async Task<ApiResponse<IReadOnlyList<CarInfoCardDto>>> HandleAsync(
    GetRecommendedCarsRequest request,
    CancellationToken ct)
  {
    var query = new GetRecommendedCarsQuery(
      request.PageIndex,
      request.PageSize
    );

    var result = await _mediator.Send(query, ct);
    if (!result.IsSuccess)
    {
      Response.Data = default;
      Response.Success = false;
      Response.Message = "An Error Occurred successfully";
    }
    else
    {
      Response.Data = result.Value;
      Response.Message = "Cars fetched successfully";
      Response.Success = true;
    }
    
    return Response;
  }
}
