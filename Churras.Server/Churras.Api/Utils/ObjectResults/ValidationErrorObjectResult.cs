using Churras.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Churras.Api.Utils.ObjectResults
{
  public class ValidationErrorObjectResult : ObjectResult
  {
    public ValidationErrorObjectResult(string message, ModelStateDictionary modelState) : base(new ValidationErrorResult(message, modelState))
    {
      StatusCode = StatusCodes.Status400BadRequest;
    }
  }
}