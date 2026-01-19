using Morent.UseCases.Features.Users.Delete;
using Morent.Web.Common;
using IMediator = MediatR.IMediator;

namespace Morent.Web.Features.Users.Delete;

public class DeleteUserEndpoint : Endpoint<DeleteUserRequest, ApiResponse<bool>>
{
  private readonly IMediator _mediator;

  public DeleteUserEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Delete(DeleteUserRequest.Route);
    AllowAnonymous();
    Group<UserGroup>();
  }

  public override async Task<ApiResponse<bool>> HandleAsync(DeleteUserRequest req, CancellationToken ct)
  {
    var result = await _mediator.Send(new DeleteUserCommand(req.Id), ct);

    Response.Success = result.IsSuccess;
    Response.Message = result.IsSuccess ? "Deleted successfully" : "Not found";
    Response.Data = result.IsSuccess;

    return Response;
  }
}
