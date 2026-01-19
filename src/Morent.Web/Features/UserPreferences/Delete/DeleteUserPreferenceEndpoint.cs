using Morent.UseCases.Features.UserPreferences.Delete;
using Morent.Web.Common;
using IMediator = MediatR.IMediator;

namespace Morent.Web.Features.UserPreferences.Delete;

public class DeleteUserPreferenceEndpoint : Endpoint<DeleteUserPreferenceRequest, ApiResponse<bool>>
{
  private readonly IMediator _mediator;

  public DeleteUserPreferenceEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Delete(DeleteUserPreferenceRequest.Route);
    AllowAnonymous();
    Group<UserPreferenceGroup>();
  }

  public override async Task<ApiResponse<bool>> HandleAsync(DeleteUserPreferenceRequest req, CancellationToken ct)
  {
    var result = await _mediator.Send(new DeleteUserPreferenceCommand(req.Id), ct);

    Response.Success = result.IsSuccess;
    Response.Message = result.IsSuccess ? "Deleted successfully" : "Not found";
    Response.Data = result.IsSuccess;

    return Response;
  }
}
