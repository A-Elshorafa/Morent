using Morent.UseCases.Features.CarCompanies.Delete;
using Morent.Web.Common;
using IMediator = MediatR.IMediator;

namespace Morent.Web.Features.CarCompanies.Delete;

public class DeleteCarCompanyEndpoint
  : Endpoint<DeleteCarCompanyRequest, ApiResponse<bool>>
{
  private readonly IMediator _mediator;

  public DeleteCarCompanyEndpoint(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Delete(DeleteCarCompanyRequest.Route);
    AllowAnonymous();
    Group<CarCompaniesGroup>();
  }

  public override async Task<ApiResponse<bool>> HandleAsync(DeleteCarCompanyRequest req, CancellationToken ct)
  {
    var result = await _mediator.Send(new DeleteCarCompanyCommand(req.CompanyId), ct);

    if (!result.IsSuccess)
    {
      Response.Success = false;
      Response.Message = "Car Company not found";
      Response.Data = false;
    }
    else
    {
      Response.Success = true;
      Response.Message = "Deleted successfully";
      Response.Data = true;
    }

    return Response;
  }
}
