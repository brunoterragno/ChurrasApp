using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Churras.Domain.Models;

namespace Churras.Domain.Exceptions
{
  [Serializable]
  public class BaseException : Exception
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
  }
}