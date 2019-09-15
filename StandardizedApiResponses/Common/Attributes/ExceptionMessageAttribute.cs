using Brandoverman.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Brandoverman.Common.Attributes
{
    public class ExceptionMessageAttribute : Attribute
    {
        public string Title { get; private set; }
        public string Message { get; private set; }
        public HttpStatusCode StatusCode { get; private set; }
        public int ErrorCode { get; private set; }

        public ExceptionMessageAttribute(int errorCode, ExceptionCategories category, string message, HttpStatusCode statusCode)
        {
            this.Title = category.DisplayName();
            this.Message = message;
            this.StatusCode = statusCode;
            this.ErrorCode = errorCode;
        }
    }
}
