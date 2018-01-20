using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Churras.Api.Models
{
  public class ValidationErrorResult
  {
    public string Message { get; set; }
    public string DeveloperMessage { get; set; }

    public List<ValidationError> Errors { get; set; } = new List<ValidationError>();

    public ValidationErrorResult() { }

    public ValidationErrorResult(string message, List<ValidationError> errors)
    {
      this.Message = message;
      this.Errors = errors;
    }

    public ValidationErrorResult(string message, ModelStateDictionary modelState)
    {
      Message = message;
      Errors = modelState.Keys.SelectMany(key =>
        modelState[key].Errors.Select(x =>
          new ValidationError(key, x.ErrorMessage, ErrorResultType.invalid_parameter)
        )
      ).ToList();
    }

    public void AddDeveloperMessage(string developerMessage)
    {
      this.DeveloperMessage = developerMessage;
    }
  }
}