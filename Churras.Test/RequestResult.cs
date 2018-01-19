using System.Net;

namespace Churras.Test
{
  public class RequestResult<T>
  {
    public HttpStatusCode StatusCode { get; private set; }
    public T Content { get; private set; }

    public RequestResult(HttpStatusCode statusCode, T content)
    {
      this.StatusCode = statusCode;
      this.Content = content;
    }
  }
}