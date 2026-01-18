using Morent.UseCases.Features.Cars.Delete;
using Morent.Web.Common;
using IMediator = MediatR.IMediator;

namespace Morent.Web.Features.Car.Delete;

public class DeleteCarEndpoint : Endpoint<DeleteCarRequest, ApiResponse<bool>>
{
  private readonly IMediator _mediator;

  public DeleteCarEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Delete(DeleteCarRequest.Route);
    AllowAnonymous();
    Group<CarGroup>();
  }

  public override async Task<ApiResponse<bool>> HandleAsync(DeleteCarRequest req, CancellationToken ct)
  {
    var result = await _mediator.Send(new DeleteCarCommand(req.Id), ct);

    Response.Success = result.IsSuccess;
    Response.Message = result.IsSuccess ? "Deleted successfully" : "Not found";
    Response.Data = result.IsSuccess;

    return Response;
  }
}
