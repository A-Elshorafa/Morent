using Morent.UseCases.DTOs;
using Morent.UseCases.Features.Users.GetAll;
using Morent.Web.Common;
using IMediator = MediatR.IMediator;

namespace Morent.Web.Features.Users.GetAll;

public class GetUserAllEndpoint : EndpointWithoutRequest<ApiResponse<List<UserDto>>>
{
  private readonly IMediator _mediator;

  public GetUserAllEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Get("");
    AllowAnonymous();
    Group<UserGroup>();
  }

  public override async Task<ApiResponse<List<UserDto>>> HandleAsync(CancellationToken ct)
  {
    var result = await _mediator.Send(new GetUserAllQuery(), ct);

    throw new Exception("Ateast exception was thrown.");
    /*Response.Success = result.IsSuccess;
    Response.Message = "List fetched";
    Response.Data = result.Value;

    return Response;
    */
  }
}
