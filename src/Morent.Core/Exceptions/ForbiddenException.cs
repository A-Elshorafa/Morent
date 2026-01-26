using Newtonsoft.Json;

namespace Morent.Core.Exceptions;

public class ForbiddenException : Exception
{
  public Dictionary<string, string>? Errors = new Dictionary<string, string>();
  public int StatusCode { get; }

  public ForbiddenException() : this("Forbidden")
  {

  }

  public ForbiddenException(string message, params object[] args) : this(403, message, args)
  {

  }
  public ForbiddenException(int code, string message, params object[] args) : this(null, code, message, args)
  {
  }

  public ForbiddenException(Exception? innerException, int code, string message, params object[] args)
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
