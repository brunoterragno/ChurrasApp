using System.Threading.Tasks;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;

namespace Churras.Test
{
  public static class RequestUtils
  {
    public static async Task<RequestResult<T>> RequestGet<T>(TestServer server, string path)
    {
      var response = await server.CreateRequest(path).GetAsync();
      var content = await response.Content.ReadAsStringAsync();

      return new RequestResult<T>(response.StatusCode, JsonConvert.DeserializeObject<T>(content));
    }
  }
}