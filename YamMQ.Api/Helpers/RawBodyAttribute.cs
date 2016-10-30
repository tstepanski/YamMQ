using System;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace YamMQ.Api.Helpers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Parameter)]
    public sealed class RawBodyAttribute : ParameterBindingAttribute
    {
        public override HttpParameterBinding GetBinding(HttpParameterDescriptor parameter)
        {
            if (parameter == null)
            {
                throw new ArgumentException("Invalid parameter");
            }

            return new RawBodyParameterBinding(parameter);
        }
    }
}