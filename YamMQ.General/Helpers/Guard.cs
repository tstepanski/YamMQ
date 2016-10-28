using System;

namespace YamMQ.General.Helpers
{
    public static class Guard
    {
        public static void ThrowIfNull(object value, string parameterName = "value")
        {
            if (value == null)
            {
                throw new ArgumentNullException(parameterName);
            }
        }
    }
}