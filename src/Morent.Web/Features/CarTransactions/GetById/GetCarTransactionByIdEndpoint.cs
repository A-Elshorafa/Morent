using Morent.UseCases.DTOs;
using Morent.UseCases.Features.CarTransactions.GetById;
using Morent.Web.Common;
using IMediator = MediatR.IMediator;

namespace Morent.Web.Features.CarTransactions.GetById;

public class GetCarTransactionByIdEndpoint : Endpoint<GetCarTransactionByIdRequest, ApiResponse<CarTransactionDetailsDto>>
{
  private readonly IMediator _mediator;

  public GetCarTransactionByIdEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Get(GetCarTransactionByIdRequest.Route);
    AllowAnonymous();
    Group<CarTransactionGroup>();
  }

  public override async Task<ApiResponse<CarTransactionDetailsDto>> HandleAsync(GetCarTransactionByIdRequest req, CancellationToken ct)
  {
    var result = await _mediator.Send(new GetCarTransactionByIdQuery(req.Id), ct);

    Response.Success = result.IsSuccess;
    Response.Message = result.IsSuccess ? "Fetched successfully" : "Not found";
    Response.Data = result.Value;

    return Response;
  }
}
