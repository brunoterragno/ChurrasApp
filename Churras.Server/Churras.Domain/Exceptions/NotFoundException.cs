using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Churras.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Churras.Domain.Exceptions
{
  public class NotFoundException : BaseException
  {
    public NotFoundException(string field, string fieldMessage, ErrorResultType type) : base(field, fieldMessage, type) { }

    public NotFoundException(List<ValidationError> errors) : base(errors) { }

    public override ObjectResult GetObjectResult(ValidationErrorResult errorResult)
    {
      return new NotFoundObjectResult(errorResult);;
    }
  }
}