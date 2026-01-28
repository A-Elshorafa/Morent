using Morent.Core.DTOs;
using Morent.UseCases.Features.CarTypes.GetAll;
using Morent.Web.Common;
using IMediator = MediatR.IMediator;

namespace Morent.Web.Features.CarTypes.GetAll;

public class GetCarTypesEndpoint 
  : EndpointWithoutRequest<ApiResponse<IReadOnlyList<CarTypeDto>>>
{
  private readonly IMediator _mediator;

  public GetCarTypesEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Get(GetCarTypesRequest.Route);
    AllowAnonymous();
    Group<CarTypesGroup>();
  }

  public override async Task<ApiResponse<IReadOnlyList<CarTypeDto>>> HandleAsync(CancellationToken ct)
  {
    var result = await _mediator.Send(new GetCarTypesQuery(), ct);
    
    if (!result.IsSuccess)
    {
      Response.Data = default;
      Response.Success = false;
      Response.Message = "An Error Occurred successfully";
    }
    else
    {
      Response.Data = result.Value;
      Response.Message = $"{result.Value.Count} cars found";
      Response.Success = true;
    }
    return Response;
  }
}
