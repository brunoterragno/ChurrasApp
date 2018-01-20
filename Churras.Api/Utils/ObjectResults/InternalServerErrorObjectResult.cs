using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Churras.Api.Utils.ObjectResults
{
  public class InternalServerErrorObjectResult : ObjectResult
  {
    public InternalServerErrorObjectResult(object error) : base(error)
    {
      StatusCode = StatusCodes.Status500InternalServerError;
    }
  }
}