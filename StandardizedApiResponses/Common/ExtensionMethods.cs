using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Brandoverman.Common.Attributes;
using Brandoverman.Common.Exceptions;

namespace Brandoverman.Common
{
    public static class ExceptionMessagesExtensions
    {
        internal static ExceptionMessageAttribute ToExceptionMessage(this ExceptionMessages exceptionMessage)
        {
            Type type = exceptionMessage.GetType();
            MemberInfo memInfo = type.GetMember(type.GetEnumName(exceptionMessage)).FirstOrDefault();
            ExceptionMessageAttribute att = memInfo
                .GetCustomAttributes(typeof(ExceptionMessageAttribute), false)
                .FirstOrDefault() as ExceptionMessageAttribute;

            return att;
        }

        public static string DisplayName(this ExceptionCategories exceptionCategories)
        {
            switch (exceptionCategories)
            {
                case ExceptionCategories.AuthenticationError:

                    return "Authentication error";

                case ExceptionCategories.GeneralError:

                    return "General error";
            }

            return string.Empty;
        }
    }
}
