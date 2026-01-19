using Microsoft.AspNetCore.Diagnostics;
using ProblemDetails = Microsoft.AspNetCore.Mvc.ProblemDetails;

namespace Morent.Web.Handlers;

public class GlobalExceptionHandler : IExceptionHandler
{
  private ILogger<GlobalExceptionHandler> _logger;
  private IProblemDetailsService _problemDetailsService;

  public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger, IProblemDetailsService problemDetailsService)
  {
    _logger = logger;
    _problemDetailsService = problemDetailsService;
  }
  
  public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
  {
    _logger.LogError(exception, "Unhandled exception occured");

    httpContext.Response.StatusCode = exception switch
    {
      _ => StatusCodes.Status500InternalServerError
    };
    
    return await _problemDetailsService.TryWriteAsync( new ProblemDetailsContext
    {
      HttpContext = httpContext,
      Exception = exception,
      ProblemDetails = new ProblemDetails
      {
        Type = exception.GetType().Name,
        Title = "An error occured",
        Detail = exception.Message
      }
    });
  }
}
