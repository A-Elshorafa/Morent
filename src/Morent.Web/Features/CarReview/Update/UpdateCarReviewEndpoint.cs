using Morent.UseCases.DTOs;
using Morent.UseCases.Features.CarReviews.Update;
using Morent.Web.Common;
using IMediator = MediatR.IMediator;

namespace Morent.Web.Features.CarReview.Update;

public class UpdateCarReviewEndpoint : Endpoint<UpdateCarReviewRequest, ApiResponse<GetCarReviewDto>>
{
  private readonly IMediator _mediator;

  public UpdateCarReviewEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Put(UpdateCarReviewRequest.Route);
    AllowAnonymous();
    Group<CarReviewGroup>();
  }

  public override async Task<ApiResponse<GetCarReviewDto>> HandleAsync(UpdateCarReviewRequest req, CancellationToken ct)
  {
    var result = await _mediator.Send(new UpdateCarReviewCommand(req), ct);

    Response.Success = result.IsSuccess;
    Response.Message = result.IsSuccess ? "Updated successfully" : "Not found";
    Response.Data = result.Value;

    return Response;
  }
}
