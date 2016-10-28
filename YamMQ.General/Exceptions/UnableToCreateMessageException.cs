using System;

namespace YamMQ.General.Exceptions
{
    public sealed class UnableToCreateMessageException : Exception
    {
        public UnableToCreateMessageException(string message) : base(message)
        {
        }

        public UnableToCreateMessageException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}