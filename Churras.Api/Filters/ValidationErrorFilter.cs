namespace Churras.Api.Filters
{
    using Churras.Api.Utils.ObjectResults;
    using Churras.Api.Utils;
    using Microsoft.AspNetCore.Mvc.Filters;

    public class ValidationErrorFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var message = RequestInfo.GetRequestErrorMessage(context.HttpContext.Request);
                context.Result = new ValidationErrorObjectResult(message, context.ModelState);
            }
        }
    }
}