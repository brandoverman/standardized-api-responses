using System.Net;
using System;
using System.Collections.Generic;
using System.Text;
using Brandoverman.Common.Attributes;

namespace Brandoverman.Common.Exceptions
{
    public enum ExceptionMessages
    {
        #region General exceptions

        [ExceptionMessage(1000, ExceptionCategories.GeneralError, "An internal server error occurred.", HttpStatusCode.InternalServerError)]
        GeneralErrorResponse,

        #endregion

        #region Custom errors

        [ExceptionMessage(1001, ExceptionCategories.CustomError, "This is a custom error.", HttpStatusCode.BadRequest)]
        CustomErrorResponse

        #endregion

    }

    public enum ExceptionCategories
    {
        AuthenticationError,
        GeneralError,
        CustomError
    }
}
