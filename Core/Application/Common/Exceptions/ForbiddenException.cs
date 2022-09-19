using System.Net;

namespace Core.Common.Exceptions;

public class ForbiddenException : CustomException
{
    public ForbiddenException(string message) : base(message, null, HttpStatusCode.Forbidden)
    {
    }
}

