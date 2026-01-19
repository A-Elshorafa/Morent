using Morent.UseCases.DTOs;
using Morent.UseCases.Features.CarReviews.Create;
using Morent.Web.Common;
using IMediator = MediatR.IMediator;

namespace Morent.Web.Features.CarReviews.Create;

public class CreateCarReviewEndpoint : Endpoint<CreateCarReviewRequest, ApiResponse<GetCarReviewDto>>
{
  private readonly IMediator _mediator;

  public CreateCarReviewEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Post(CreateCarReviewRequest.Route);
    AllowAnonymous();
    Group<CarReviewGroup>();
  }

  public override async Task<ApiResponse<GetCarReviewDto>> HandleAsync(CreateCarReviewRequest req, CancellationToken ct)
  {
    var result = await _mediator.Send(new CreateCarReviewCommand(req), ct);

    Response.Success = result.IsSuccess;
    Response.Message = result.IsSuccess ? "Created successfully" : "Error creating";
    Response.Data = result.Value;

    return Response;
  }
}
