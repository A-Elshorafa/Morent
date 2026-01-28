using Morent.Core.DTOs;
using Morent.UseCases.Features.CarReviews.GetAll;
using Morent.Web.Common;
using IMediator = MediatR.IMediator;

namespace Morent.Web.Features.CarReviews.GetAll;

public class GetCarReviewAllEndpoint : EndpointWithoutRequest<ApiResponse<List<GetCarReviewDto>>>
{
  private readonly IMediator _mediator;

  public GetCarReviewAllEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Get("");
    AllowAnonymous();
    Group<CarReviewGroup>();
  }

  public override async Task<ApiResponse<List<GetCarReviewDto>>> HandleAsync(CancellationToken ct)
  {
    var result = await _mediator.Send(new GetCarReviewAllQuery(), ct);

    Response.Success = result.IsSuccess;
    Response.Message = "List fetched";
    Response.Data = result.Value;

    return Response;
  }
}
