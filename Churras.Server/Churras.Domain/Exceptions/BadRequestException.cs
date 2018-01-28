using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Churras.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Churras.Domain.Exceptions
{
  public class BadRequestException : BaseException
  {
    public BadRequestException(string field, string fieldMessage, ErrorResultType type) : base(field, fieldMessage, type) { }

    public BadRequestException(List<ValidationError> errors) : base(errors) { }

    public override ObjectResult GetObjectResult(ValidationErrorResult errorResult)
    {
      return new BadRequestObjectResult(errorResult);;
    }
  }
}