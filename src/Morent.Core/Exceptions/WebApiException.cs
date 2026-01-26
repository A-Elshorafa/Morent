using Newtonsoft.Json;

namespace Morent.Core.Exceptions;

public class WebApiException : Exception
{
  public Dictionary<string, string>? Errors = new Dictionary<string, string>();
  public int StatusCode { get; }

  public WebApiException() : this("Internal Server Error")
  {

  }

  public WebApiException(string message, params object[] args) : this(400, message, args)
  {

  }
  public WebApiException(int code, string message, params object[] args) : this(null, code, message, args)
  {
  }

  public WebApiException(Exception? innerException, int code, string message, params object[] args)
      : base(string.Format(message, args), innerException)
  {
    StatusCode = code;

  }

  public override string ToString()
  {
    var inner = InnerException != null ? InnerException.Message : "";
    var subInner = InnerException?.InnerException != null ? InnerException.InnerException.Message : "";
    var error = new
    {
      StatusCode,
      message = Message,
      Details = inner,
      ExtraDetails = subInner
    };
    return JsonConvert.SerializeObject(error);
  }
}
