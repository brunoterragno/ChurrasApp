using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Churras.Test
{
  public static class RequestUtils
  {
    public static async Task<RequestResult<T>> RequestGet<T>(HttpClient client, string path)
    {
      var response = await client.GetAsync(path);
      var content = await response.Content.ReadAsStringAsync();

      return new RequestResult<T>(response.StatusCode, JsonConvert.DeserializeObject<T>(content));
    }

    public static async Task<RequestResult<T>> RequestPost<T>(HttpClient client, string path, object body)
    {
      var response = await client.PostAsync(path, new StringContent(JsonConvert.SerializeObject(body)));
      var content = await response.Content.ReadAsStringAsync();

      return new RequestResult<T>(response.StatusCode, JsonConvert.DeserializeObject<T>(content));
    }
  }
}