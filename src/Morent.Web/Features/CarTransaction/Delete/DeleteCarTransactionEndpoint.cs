using Morent.UseCases.Features.CarTransactions.Delete;
using Morent.Web.Common;
using IMediator = MediatR.IMediator;

namespace Morent.Web.Features.CarTransaction.Delete;

public class DeleteCarTransactionEndpoint : Endpoint<DeleteCarTransactionRequest, ApiResponse<bool>>
{
  private readonly IMediator _mediator;

  public DeleteCarTransactionEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Delete(DeleteCarTransactionRequest.Route);
    AllowAnonymous();
    Group<CarTransactionGroup>();
  }

  public override async Task<ApiResponse<bool>> HandleAsync(DeleteCarTransactionRequest req, CancellationToken ct)
  {
    var result = await _mediator.Send(new DeleteCarTransactionCommand(req.Id), ct);

    Response.Success = result.IsSuccess;
    Response.Message = result.IsSuccess ? "Deleted successfully" : "Not found";
    Response.Data = result.IsSuccess;

    return Response;
  }
}
