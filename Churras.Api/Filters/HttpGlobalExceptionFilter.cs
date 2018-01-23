namespace Churras.Api.Filters
{
  using System.Collections.Generic;
  using System.Linq;
  using System.Net;
  using Churras.Api.Utils.ObjectResults;
  using Churras.Api.Utils;
  using Churras.Domain.Exceptions;
  using Churras.Domain.Models;
  using Microsoft.AspNetCore.Hosting;
  using Microsoft.AspNetCore.Mvc.Filters;
  using Microsoft.AspNetCore.Mvc;
  using Microsoft.Extensions.Logging;

  public class HttpGlobalExceptionFilter : IExceptionFilter
  {
    private readonly IHostingEnvironment _env;

    private readonly ILogger<HttpGlobalExceptionFilter> _logger;

    public HttpGlobalExceptionFilter(IHostingEnvironment env, ILogger<HttpGlobalExceptionFilter> logger)
    {
      this._env = env;
      this._logger = logger;
    }

    public void OnException(ExceptionContext context)
    {
      var message = RequestInfo.GetRequestErrorMessage(context.HttpContext.Request);

      if (context.Exception is BaseException)
      {
        var ex = context.Exception as BaseException;
        var errorResult = new ValidationErrorResult(message, ex.Errors);
        var objectResult = GetObjectResultType(errorResult);
        this.BuildResponse(context, objectResult);
      }
      else
      {
        LogInternalServerError(context);
        var errorResult = new ValidationErrorResult(message, GetInternalServerError());

        if (_env.IsDevelopment())
          errorResult.AddDeveloperMessage(context.Exception.Message);

        var objectResult = GetObjectResultType(errorResult);
        this.BuildResponse(context, objectResult);
      }
    }

    private void LogInternalServerError(ExceptionContext context)
    {
      _logger.LogError(new EventId(context.Exception.HResult),
        context.Exception,
        context.Exception.Message);
    }

    private List<ValidationError> GetInternalServerError()
    {
      var errorMsg = "An error occurred. Try it again.";
      var errors = new List<ValidationError>();
      errors.Add(new ValidationError(null, errorMsg, ErrorResultType.server_error));

      return errors;
    }

    private ObjectResult GetObjectResultType(ValidationErrorResult errorResult)
    {
      var type = errorResult.Errors.FirstOrDefault().Type;
      switch (type)
      {
        case ErrorResultType.invalid_parameter:
          return new BadRequestObjectResult(errorResult);
        case ErrorResultType.not_found:
          return new NotFoundObjectResult(errorResult);
        default:
          return new InternalServerErrorObjectResult(errorResult);
      }
    }

    private void BuildResponse(ExceptionContext context, ObjectResult result)
    {
      context.Result = result;
      context.ExceptionHandled = true;
    }
  }
}