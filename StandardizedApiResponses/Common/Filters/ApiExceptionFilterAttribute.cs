using Brandoverman.Common.Exceptions;
using Brandoverman.Common.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Brandoverman.Common.Filters
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override Task OnExceptionAsync(ExceptionContext context)
        {
            var exception = context.Exception;
            Guid logId = Guid.NewGuid();
            Dictionary<string, object> errorData = new Dictionary<string, object>();

            var errorResponse = new ApiErrorResponse(context.HttpContext.Request)
            {
                Id = $"{logId}"
            };

            ApiException apiException = exception as ApiException;

            if (apiException == null)
            {
                apiException = new ApiException(ExceptionMessages.GeneralErrorResponse, null);
            }

            errorResponse.Title = apiException.Title;
            errorResponse.StatusCode = apiException.StatusCode;
            errorResponse.Status = apiException.Status;
            errorResponse.ErrorCode = apiException.ErrorCode;

            context.HttpContext.Response.StatusCode = apiException.StatusCode;
            context.HttpContext.Response.ContentType = "application/json";
            errorData.Add("message", exception.Message);
            errorResponse.StatusCode = apiException.StatusCode;
            errorData.Add("ref", errorResponse.Id);

#if DEBUG
            if (exception.InnerException != null) errorData.Add("innerException", exception.InnerException.ToString());
            errorData.Add("stackTrace", exception.StackTrace);
#endif

            errorResponse.Data = errorData;

            context.HttpContext.Response.Headers.Add("Api-Version", System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString());
            context.Result = new JsonResult(errorResponse);

            return base.OnExceptionAsync(context);
        }
    }
}
