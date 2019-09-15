using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Brandoverman.Common.Responses
{
    public class ApiErrorResponse : ApiResultResponse
    {
        public string Status { get; set; }
        public int StatusCode = (int)HttpStatusCode.InternalServerError;
        public int ErrorCode { get; set; }
        public string Title { get; set; }
        public string Id { get; set; }

        public ApiErrorResponse(HttpRequest request) : base(request, null)
        {
            base.Success = false;
        }
    }
}
