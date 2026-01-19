using Morent.UseCases.DTOs;
using Morent.UseCases.Features.UserPreferences.Update;
using Morent.Web.Common;
using IMediator = MediatR.IMediator;

namespace Morent.Web.Features.UserPreferences.Update;

public class UpdateUserPreferenceEndpoint : Endpoint<UpdateUserPreferenceRequest, ApiResponse<UserPreferenceDto>>
{
  private readonly IMediator _mediator;

  public UpdateUserPreferenceEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Put(UpdateUserPreferenceRequest.Route);
    AllowAnonymous();
    Group<UserPreferenceGroup>();
  }

  public override async Task<ApiResponse<UserPreferenceDto>> HandleAsync(UpdateUserPreferenceRequest req, CancellationToken ct)
  {
    var result = await _mediator.Send(new UpdateUserPreferenceCommand(req), ct);

    Response.Success = result.IsSuccess;
    Response.Message = result.IsSuccess ? "Updated successfully" : "Not found";
    Response.Data = result.Value;

    return Response;
  }
}
