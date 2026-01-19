using Morent.UseCases.Features.CarReviews.Delete;
using Morent.Web.Common;
using IMediator = MediatR.IMediator;

namespace Morent.Web.Features.CarReviews.Delete;

public class DeleteCarReviewEndpoint : Endpoint<DeleteCarReviewRequest, ApiResponse<bool>>
{
  private readonly IMediator _mediator;

  public DeleteCarReviewEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Delete(DeleteCarReviewRequest.Route);
    AllowAnonymous();
    Group<CarReviewGroup>();
  }

  public override async Task<ApiResponse<bool>> HandleAsync(DeleteCarReviewRequest req, CancellationToken ct)
  {
    var result = await _mediator.Send(new DeleteCarReviewCommand(req.Id), ct);

    Response.Success = result.IsSuccess;
    Response.Message = result.IsSuccess ? "Deleted successfully" : "Not found";
    Response.Data = result.IsSuccess;

    return Response;
  }
}
