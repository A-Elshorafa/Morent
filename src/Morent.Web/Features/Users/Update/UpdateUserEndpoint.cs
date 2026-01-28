using Morent.Core.DTOs;
using Morent.UseCases.Features.Users.Update;
using Morent.Web.Common;
using IMediator = MediatR.IMediator;

namespace Morent.Web.Features.Users.Update;

public class UpdateUserEndpoint : Endpoint<UpdateUserRequest, ApiResponse<UserDto>>
{
  private readonly IMediator _mediator;

  public UpdateUserEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Put(UpdateUserRequest.Route);
    AllowAnonymous();
    Group<UserGroup>();
  }

  public override async Task<ApiResponse<UserDto>> HandleAsync(UpdateUserRequest req, CancellationToken ct)
  {
    var result = await _mediator.Send(new UpdateUserCommand(req), ct);

    Response.Success = result.IsSuccess;
    Response.Message = result.IsSuccess ? "Updated successfully" : "Not found";
    Response.Data = result.Value;

    return Response;
  }
}
