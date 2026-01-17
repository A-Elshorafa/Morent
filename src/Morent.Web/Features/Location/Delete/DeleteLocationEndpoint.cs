using Morent.UseCases.Features.Locations.Delete;
using Morent.Web.Common;
using IMediator = MediatR.IMediator;

namespace Morent.Web.Features.Location.Delete;

public class DeleteLocationEndpoint : Endpoint<DeleteLocationRequest, ApiResponse<bool>>
{
  private readonly IMediator _mediator;

  public DeleteLocationEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Delete(DeleteLocationRequest.Route);
    AllowAnonymous();
    Group<LocationGroup>();
  }

  public override async Task<ApiResponse<bool>> HandleAsync(DeleteLocationRequest req, CancellationToken ct)
  {
    var result = await _mediator.Send(new DeleteLocationCommand(req.Id), ct);

    Response.Success = result.IsSuccess;
    Response.Message = result.IsSuccess ? "Deleted successfully" : "Not found";
    Response.Data = result.IsSuccess;

    return Response;
  }
}
