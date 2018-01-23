using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Churras.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Churras.Domain.Exceptions
{
  [Serializable]
  public abstract class BaseException : Exception
  {
    public List<ValidationError> Errors { get; } = new List<ValidationError>();

    public BaseException(string field, string fieldMessage, ErrorResultType type)
    {
      this.Errors.Add(new ValidationError(field, fieldMessage, type));
    }

    public BaseException(List<ValidationError> errors) : base()
    {
      this.Errors = errors;
    }

    public abstract ObjectResult GetObjectResult(ValidationErrorResult errorResult);
  }
}