using Morent.UseCases.DTOs;
using Morent.UseCases.Features.CarTransactions.Update;
using Morent.Web.Common;
using IMediator = MediatR.IMediator;

namespace Morent.Web.Features.CarTransactions.Update;

public class UpdateCarTransactionEndpoint : Endpoint<UpdateCarTransactionRequest, ApiResponse<CarTransactionDetailsDto>>
{
  private readonly IMediator _mediator;

  public UpdateCarTransactionEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Put(UpdateCarTransactionRequest.Route);
    AllowAnonymous();
    Group<CarTransactionGroup>();
  }

  public override async Task<ApiResponse<CarTransactionDetailsDto>> HandleAsync(UpdateCarTransactionRequest req, CancellationToken ct)
  {
    var result = await _mediator.Send(new UpdateCarTransactionCommand(req), ct);

    Response.Success = result.IsSuccess;
    Response.Message = result.IsSuccess ? "Updated successfully" : "Not found";
    Response.Data = result.Value;

    return Response;
  }
}
