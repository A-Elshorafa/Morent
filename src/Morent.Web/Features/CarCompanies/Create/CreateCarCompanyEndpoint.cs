using Morent.Core.DTOs;
using Morent.UseCases.Features.CarCompanies.Create;
using Morent.Web.Common;
using IMediator = MediatR.IMediator;

namespace Morent.Web.Features.CarCompanies.Create;

public class CreateCarCompanyEndpoint
  : Endpoint<CreateCarCompanyRequest, ApiResponse<CarCompanyDto>>
{
  private readonly IMediator _mediator;

  public CreateCarCompanyEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Post(CreateCarCompanyRequest.Route);
    AllowAnonymous();
    Group<CarCompaniesGroup>();
  }

  public override async Task<ApiResponse<CarCompanyDto>> HandleAsync(
    CreateCarCompanyRequest req, CancellationToken ct)
  {
    var result = await _mediator.Send(new CreateCarCompanyCommand(req.CompanyName), ct);

    if (!result.IsSuccess)
    {
      Response.Success = false;
      Response.Message = "Error creating company";
      Response.Data = default;
    }
    else
    {
      Response.Success = true;
      Response.Message = "Company created successfully";
      Response.Data = result.Value;
    }

    return Response;
  }
}
