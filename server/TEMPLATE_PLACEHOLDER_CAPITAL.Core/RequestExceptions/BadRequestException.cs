using System;

namespace TEMPLATE_PLACEHOLDER_CAPITAL.Core.RequestExceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message): base(message)
        {
        }
    }
}