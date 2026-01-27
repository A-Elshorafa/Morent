using Morent.UseCases.DTOs;
using Morent.UseCases.Features.Cars.GetAll;
using Morent.Web.Common;
using IMediator = MediatR.IMediator;

namespace Morent.Web.Features.Car.GetAll;

public class GetCarAllEndpoint : Endpoint<GetCarAllRequest, ApiResponse<List<CarInfoCardDto>>>
{
  private readonly IMediator _mediator;

  public GetCarAllEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Get(GetCarAllRequest.Route);
    Group<CarGroup>();
  }

  public override async Task<ApiResponse<List<CarInfoCardDto>>> HandleAsync(
    GetCarAllRequest request,
    CancellationToken ct)
  {
    var result = await _mediator.Send(new GetCarAllQuery(
      pageSize: request.PageSize,
      pageNumber: request.PageNumber,
      searchToken: request.SearchToken
    ), ct);

    if (result.IsSuccess)
    {
      Response.Data = result.Value;
      Response.Success = result.IsSuccess;
      Response.Message = result.IsSuccess? "Success" : "Failed";
    }
    else
    {
      Response.Success = false;
      Response.Message = "Failed";
      Response.Data = null;
    }

    return Response;
  }
}
