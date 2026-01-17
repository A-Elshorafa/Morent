using Morent.UseCases.DTOs;
using Morent.UseCases.Features.CarCompanies.GetAll;
using Morent.Web.Common;
using IMediator = MediatR.IMediator;

namespace Morent.Web.Features.CarCompanies.GetList;

public class GetCarCompanyListEndpoint
  : EndpointWithoutRequest<ApiResponse<List<CarCompanyDto>>>
{
  private readonly IMediator _mediator;

  public GetCarCompanyListEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }
  
  public override void Configure()
  {
    Get(GetCarCompanyListRequest.Route);
    AllowAnonymous();
    Group<CarCompaniesGroup>();
  }

  public override async Task<ApiResponse<List<CarCompanyDto>>> HandleAsync(CancellationToken ct)
  {
    var result = await _mediator.Send(new GetCarCompanyListQuery(), ct);

    Response.Success = true;
    Response.Message = "Success";
    Response.Data = result.Value;

    return Response;
  }
}
