using Microsoft.AspNetCore.Identity.Data;
using Morent.UseCases.DTOs;
using Morent.UseCases.Features.Auth;
using Morent.Web.Common;
using Morent.Web.Features.CarCompanies;
using IMediator = MediatR.IMediator;

namespace Morent.Web.Features.Auth;

public sealed class LoginEndpoint : Endpoint<LoginRequest, ApiResponse<LoginResponseDto>>
{
  private readonly IMediator _mediator;

  public LoginEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Post(LoginRequest.Route);
    Group<AuthGroup>();
    AllowAnonymous();
  }

  public override async Task HandleAsync(LoginRequest req, CancellationToken ct)
  {
    var result = await _mediator.Send(new LoginCommand(req.Email, req.Password), ct);

    var res = ApiResponse<LoginResponseDto>.Ok(result);
    Response.Data = res.Data;
    Response.Message = res.Message;
    Response.Success = res.Success;
    
    await Send.OkAsync(Response, ct);
  }
}
