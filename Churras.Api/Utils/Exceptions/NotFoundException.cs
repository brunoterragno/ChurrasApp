using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Churras.Api.Models;

namespace Churras.Api.Utils.Exceptions
{
  public class NotFoundException : BaseException
  {
    public NotFoundException(string field, string fieldMessage, ErrorResultType type) : base(field, fieldMessage, type) { }

    public NotFoundException(List<ValidationError> errors) : base(errors) { }
  }
}