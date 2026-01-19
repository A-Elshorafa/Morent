using Morent.UseCases.Features.CarTypes.Delete;
using Morent.Web.Common;
using IMediator = MediatR.IMediator;

namespace Morent.Web.Features.CarTypes.Delete;

public class DeleteCarTypeEndpoint
  : Endpoint<DeleteCarTypeRequest, ApiResponse<bool>>
{
  private readonly IMediator _mediator;

  public DeleteCarTypeEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Delete(DeleteCarTypeRequest.Route);
    AllowAnonymous();
    Group<CarTypesGroup>();
  }

  public override async Task<ApiResponse<bool>> HandleAsync(
    DeleteCarTypeRequest req, CancellationToken ct)
  {
    var result = await _mediator.Send(new DeleteCarTypeCommand(req.Id), ct);

    if (!result.IsSuccess)
    {
      Response.Data = default;
      Response.Success = false;
      Response.Message = string.Join(", ", result.Errors);
    }
    else
    {
      Response.Data = result.Value;
      Response.Message = "Car type deleted";
      Response.Success = true;
    }
    return Response;
  }
}
