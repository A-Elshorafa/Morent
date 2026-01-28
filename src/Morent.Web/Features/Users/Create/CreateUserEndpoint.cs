using Morent.Core.DTOs;
using Morent.UseCases.Features.Users.Create;
using Morent.Web.Common;
using IMediator = MediatR.IMediator;

namespace Morent.Web.Features.Users.Create;

public class CreateUserEndpoint : Endpoint<CreateUserRequest, ApiResponse<UserDto>>
{
  private readonly IMediator _mediator;

  public CreateUserEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Post(CreateUserRequest.Route);
    AllowAnonymous();
    Group<UserGroup>();
  }

  public override async Task<ApiResponse<UserDto>> HandleAsync(CreateUserRequest req, CancellationToken ct)
  {
    var result = await _mediator.Send(new CreateUserCommand(req), ct);

    Response.Success = result.IsSuccess;
    Response.Message = result.IsSuccess ? "Created successfully" : "Error creating";
    Response.Data = result.Value;

    return Response;
  }
}
