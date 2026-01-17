using Morent.UseCases.DTOs;
using Morent.UseCases.Features.CarCompanies.Update;
using Morent.Web.Common;
using IMediator = MediatR.IMediator;

namespace Morent.Web.Features.CarCompanies.Update;

public class UpdateCarCompanyEndpoint
  : Endpoint<UpdateCarCompanyRequest, ApiResponse<CarCompanyDto>>
{
  private readonly IMediator _mediator;

  public UpdateCarCompanyEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Put(UpdateCarCompanyRequest.Route);
    AllowAnonymous();
    Group<CarCompaniesGroup>();
  }

  public override async Task<ApiResponse<CarCompanyDto>> HandleAsync(UpdateCarCompanyRequest req, CancellationToken ct)
  {
    var result = await _mediator.Send(
      new UpdateCarCompanyCommand(req.CompanyId, req.CompanyName), ct);

    if (!result.IsSuccess)
    {
      Response.Success = false;
      Response.Message = "Car Company not found";
      Response.Data = default;
    }
    else
    {
      Response.Success = true;
      Response.Message = "Updated successfully";
      Response.Data = result.Value;
    }

    return Response;
  }
}

