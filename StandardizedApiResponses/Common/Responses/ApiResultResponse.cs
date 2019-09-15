using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brandoverman.Common.Responses
{
    public class ApiResultResponse
    {
        [JsonProperty(Order = 2)]
        public string Method { get; set; }

        [JsonProperty(Order = 1)]
        public bool Success { get; set; } = true;

        [JsonProperty(Order = 4)]
        public object Data { get; set; } = null;

        [JsonProperty(Order = 3)]
        public string Path { get; set; } = null;

        public ApiResultResponse(HttpRequest request, ObjectResult res)
        {
            this.Method = request.Method;
            this.Path = request.Path;
            if (res != null) this.Data = res.Value;
        }
    }
}
