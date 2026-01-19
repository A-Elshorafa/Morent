using Morent.UseCases.DTOs;
using Morent.UseCases.Features.CarReviews.GetById;
using Morent.Web.Common;
using IMediator = MediatR.IMediator;

namespace Morent.Web.Features.CarReviews.GetById;

public class GetCarReviewByIdEndpoint : Endpoint<GetCarReviewByIdRequest, ApiResponse<GetCarReviewDto>>
{
  private readonly IMediator _mediator;

  public GetCarReviewByIdEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Get(GetCarReviewByIdRequest.Route);
    AllowAnonymous();
    Group<CarReviewGroup>();
  }

  public override async Task<ApiResponse<GetCarReviewDto>> HandleAsync(GetCarReviewByIdRequest req, CancellationToken ct)
  {
    var result = await _mediator.Send(new GetCarReviewByIdQuery(req.Id), ct);

    Response.Success = result.IsSuccess;
    Response.Message = result.IsSuccess ? "Fetched successfully" : "Not found";
    Response.Data = result.Value;

    return Response;
  }
}
