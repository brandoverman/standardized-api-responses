using Brandoverman.Common.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Brandoverman.Common.Filters
{
    public class ApiResultFilterAttribute : ResultFilterAttribute
    {
        public override Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            ObjectResult objectResult = context.Result as ObjectResult;
            ApiResultResponse apiResponse = new ApiResultResponse(context.HttpContext.Request, objectResult);

            context.HttpContext.Response.Headers.Add("Api-Version", System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString());
            context.Result = new JsonResult(apiResponse);

            return base.OnResultExecutionAsync(context, next);
        }
    }
}
