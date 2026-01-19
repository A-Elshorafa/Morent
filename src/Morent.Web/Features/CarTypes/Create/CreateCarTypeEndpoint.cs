using Morent.UseCases.DTOs;
using Morent.UseCases.Features.CarTypes.Create;
using Morent.Web.Common;
using IMediator = MediatR.IMediator;

namespace Morent.Web.Features.CarTypes.Create;

public class CreateCarTypeEndpoint 
  : Endpoint<CreateCarTypeRequest, ApiResponse<CarTypeDto>>
{
  private readonly IMediator _mediator;

  public CreateCarTypeEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Post(CreateCarTypeRequest.Route);
    AllowAnonymous();
    Group<CarTypesGroup>();
  }

  public override async Task<ApiResponse<CarTypeDto>> HandleAsync(
    CreateCarTypeRequest req, CancellationToken ct)
  {
    var result = await _mediator.Send(new CreateCarTypeCommand(req.TypeName), ct);
 
    if (!result.IsSuccess)
    {
      Response.Data = default;
      Response.Success = false;
      Response.Message = "An Error Occurred successfully";
    }
    else
    {
      Response.Data = result.Value;
      Response.Message = "Cars fetched successfully";
      Response.Success = true;
    }
    return Response;
  }
}

