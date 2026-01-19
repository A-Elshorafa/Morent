using Morent.UseCases.DTOs;
using Morent.UseCases.Features.UserPreferences.GetById;
using Morent.Web.Common;
using IMediator = MediatR.IMediator;

namespace Morent.Web.Features.UserPreferences.GetById;

public class GetUserPreferenceByIdEndpoint : Endpoint<GetUserPreferenceByIdRequest, ApiResponse<UserPreferenceDto>>
{
  private readonly IMediator _mediator;

  public GetUserPreferenceByIdEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Get(GetUserPreferenceByIdRequest.Route);
    AllowAnonymous();
    Group<UserPreferenceGroup>();
  }

  public override async Task<ApiResponse<UserPreferenceDto>> HandleAsync(GetUserPreferenceByIdRequest req, CancellationToken ct)
  {
    var result = await _mediator.Send(new GetUserPreferenceByIdQuery(req.Id), ct);

    Response.Success = result.IsSuccess;
    Response.Message = result.IsSuccess ? "Fetched successfully" : "Not found";
    Response.Data = result.Value;

    return Response;
  }
}
