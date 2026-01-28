using Morent.Core.DTOs;
using Morent.UseCases.Features.UserPreferences.GetAll;
using Morent.Web.Common;
using IMediator = MediatR.IMediator;

namespace Morent.Web.Features.UserPreferences.GetAll;

public class GetUserPreferenceAllEndpoint : EndpointWithoutRequest<ApiResponse<List<UserPreferenceDto>>>
{
  private readonly IMediator _mediator;

  public GetUserPreferenceAllEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Get("");
    AllowAnonymous();
    Group<UserPreferenceGroup>();
  }

  public override async Task<ApiResponse<List<UserPreferenceDto>>> HandleAsync(CancellationToken ct)
  {
    var result = await _mediator.Send(new GetUserPreferenceAllQuery(), ct);

    Response.Success = result.IsSuccess;
    Response.Message = "List fetched";
    Response.Data = result.Value;

    return Response;
  }
}
