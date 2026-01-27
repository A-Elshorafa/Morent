using Morent.UseCases.DTOs;
using Morent.UseCases.Features.CarTransactions.Create;
using Morent.Web.Common;
using IMediator = MediatR.IMediator;

namespace Morent.Web.Features.CarTransactions.Create;

public class CreateCarTransactionEndpoint : Endpoint<CreateCarTransactionRequest, ApiResponse<CarTransactionDetailsDto>>
{
  private readonly IMediator _mediator;

  public CreateCarTransactionEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Post(CreateCarTransactionRequest.Route);
    AllowAnonymous();
    Group<CarTransactionGroup>();
  }

  public override async Task<ApiResponse<CarTransactionDetailsDto>> HandleAsync(CreateCarTransactionRequest req, CancellationToken ct)
  {
    var result = await _mediator.Send(new CreateCarTransactionCommand(req), ct);

    Response.Success = result.IsSuccess;
    Response.Message = result.IsSuccess ? "Created successfully" : result.Errors.First();
    Response.Data = result.Value;

    return Response;
  }
}
