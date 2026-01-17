using Morent.Web.Common;
using IMediator = MediatR.IMediator;
using Morent.UseCases.Features.CarTypes.Update;

namespace Morent.Web.Features.CarType.Update;

public class UpdateCarTypeEndpoint
  : Endpoint<UpdateCarTypeRequest, ApiResponse<bool>>
{
  private readonly IMediator _mediator;

  public UpdateCarTypeEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Put(UpdateCarTypeRequest.Route);
    AllowAnonymous();
    Group<CarTypesGroup>();
  }

  public override async Task<ApiResponse<bool>> HandleAsync(
    UpdateCarTypeRequest req, CancellationToken ct)
  {
    var result = await _mediator.Send(
      new UpdateCarTypeCommand(req.Id, req.TypeName), ct);

    if (!result.IsSuccess)
    {
      Response.Data = default;
      Response.Success = false;
      Response.Message = "An Error Occurred";
    }
    else
    {
      Response.Data = result.Value;
      Response.Message = "Car type updated";
      Response.Success = true;
    }
    return Response;
  }
}
