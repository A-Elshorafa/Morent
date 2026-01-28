using Morent.Core.DTOs;
using Morent.UseCases.Features.CarCompanies.GetById;
using Morent.Web.Common;
using IMediator = MediatR.IMediator;

namespace Morent.Web.Features.CarCompanies.Update;

public class GetCarCompanyByIdEndpoint
  : Endpoint<GetCarCompanyByIdRequest, ApiResponse<CarCompanyDto>>
{
  private readonly IMediator _mediator;

  public GetCarCompanyByIdEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Get(GetCarCompanyByIdRequest.Route);
    Group<CarCompaniesGroup>();
  }

  public override async Task<ApiResponse<CarCompanyDto>> HandleAsync(
    GetCarCompanyByIdRequest req, CancellationToken ct)
  {
    var result = await _mediator.Send(new GetCarCompanyByIdQuery(req.CompanyId), ct);

    if (!result.IsSuccess)
    {
      Response.Success = false;
      Response.Message = "Car Company not found";
      Response.Data = default;
    }
    else
    {
      Response.Success = true;
      Response.Message = "Fetched successfully";
      Response.Data = result.Value;
    }

    return Response;
  }
}

