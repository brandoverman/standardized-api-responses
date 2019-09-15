using System;
using System.Collections.Generic;
using System.Text;

namespace Brandoverman.Common.Exceptions
{
    public class ApiException : Exception
    {
        public string Title { get; private set; }
        public int StatusCode { get; private set; }
        public string Status { get; private set; }
        public int ErrorCode { get; private set; }

        public ApiException(ExceptionMessages enumValue, Exception innerException) : base(enumValue.ToExceptionMessage().Message, innerException)
        {
            var m = enumValue.ToExceptionMessage();

            this.Title = m.Title;
            this.StatusCode = (int)m.StatusCode;
            this.Status = m.StatusCode.ToString();
            this.ErrorCode = m.ErrorCode;
        }
    }
}
