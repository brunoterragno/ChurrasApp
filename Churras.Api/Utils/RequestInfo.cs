using Microsoft.AspNetCore.Http;

namespace Churras.Api.Utils
{
  public static class RequestInfo
  {
    public static string GetRequestErrorMessage(HttpRequest request)
    {
      return $"Error when requesting {request.Method} {request.Path}";
    }
  }
}