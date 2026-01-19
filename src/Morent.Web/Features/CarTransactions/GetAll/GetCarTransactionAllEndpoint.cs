using Morent.UseCases.DTOs;
using Morent.UseCases.Features.CarTransactions.GetAll;
using Morent.Web.Common;
using IMediator = MediatR.IMediator;

namespace Morent.Web.Features.CarTransactions.GetAll;

public class GetCarTransactionAllEndpoint : EndpointWithoutRequest<ApiResponse<List<CarTransactionDetailsDto>>>
{
  private readonly IMediator _mediator;

  public GetCarTransactionAllEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Get("");
    AllowAnonymous();
    Group<CarTransactionGroup>();
  }

  public override async Task<ApiResponse<List<CarTransactionDetailsDto>>> HandleAsync(CancellationToken ct)
  {
    var result = await _mediator.Send(new GetCarTransactionAllQuery(), ct);

    Response.Success = result.IsSuccess;
    Response.Message = "List fetched";
    Response.Data = result.Value;

    return Response;
  }
}
