using Morent.UseCases.DTOs;
using Morent.UseCases.Features.UserPreferences.Create;
using Morent.Web.Common;
using IMediator = MediatR.IMediator;

namespace Morent.Web.Features.UserPreferences.Create;

public class CreateUserPreferenceEndpoint : Endpoint<CreateUserPreferenceRequest, ApiResponse<UserPreferenceDto>>
{
  private readonly IMediator _mediator;

  public CreateUserPreferenceEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Post(CreateUserPreferenceRequest.Route);
    AllowAnonymous();
    Group<UserPreferenceGroup>();
  }

  public override async Task<ApiResponse<UserPreferenceDto>> HandleAsync(CreateUserPreferenceRequest req, CancellationToken ct)
  {
    var result = await _mediator.Send(new CreateUserPreferenceCommand(req), ct);

    Response.Success = result.IsSuccess;
    Response.Message = result.IsSuccess ? "Created successfully" : "Error creating";
    Response.Data = result.Value;

    return Response;
  }
}
