using Morent.UseCases.DTOs;
using Morent.UseCases.Features.Users.GetById;
using Morent.Web.Common;
using IMediator = MediatR.IMediator;

namespace Morent.Web.Features.User.GetById;

public class GetUserByIdEndpoint : Endpoint<GetUserByIdRequest, ApiResponse<UserDto>>
{
  private readonly IMediator _mediator;

  public GetUserByIdEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Get(GetUserByIdRequest.Route);
    AllowAnonymous();
    Group<UserGroup>();
  }

  public override async Task<ApiResponse<UserDto>> HandleAsync(GetUserByIdRequest req, CancellationToken ct)
  {
    var result = await _mediator.Send(new GetUserByIdQuery(req.Id), ct);

    Response.Success = result.IsSuccess;
    Response.Message = result.IsSuccess ? "Fetched successfully" : "Not found";
    Response.Data = result.Value;

    return Response;
  }
}
