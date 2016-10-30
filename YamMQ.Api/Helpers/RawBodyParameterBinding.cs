using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Metadata;

namespace YamMQ.Api.Helpers
{
    public sealed class RawBodyParameterBinding : HttpParameterBinding
    {
        public RawBodyParameterBinding(HttpParameterDescriptor descriptor) : base(descriptor)
        {
        }

        public override bool WillReadBody => true;

        public override Task ExecuteBindingAsync(ModelMetadataProvider metadataProvider, HttpActionContext actionContext,
            CancellationToken cancellationToken)
        {
            var binding = actionContext.ActionDescriptor.ActionBinding;

            if (
                (binding.ParameterBindings.Count(
                     parameterBinding => parameterBinding.Descriptor.ParameterType != typeof(CancellationToken)) > 1) ||
                (actionContext.Request.Method == HttpMethod.Get))
            {
                return EmptyTask.Start();
            }

            var type = binding.ParameterBindings[0].Descriptor.ParameterType;

            if (type == typeof(string))
            {
                return actionContext.Request.Content
                    .ReadAsStringAsync()
                    .ContinueWith(task =>
                    {
                        var stringResult = task.Result;
                        SetValue(actionContext, stringResult);
                    }, cancellationToken);
            }

            if (type == typeof(byte[]))
            {
                return actionContext.Request.Content
                    .ReadAsByteArrayAsync()
                    .ContinueWith(task =>
                    {
                        var result = task.Result;
                        SetValue(actionContext, result);
                    }, cancellationToken);
            }

            throw new InvalidOperationException("Only string and byte[] are supported for [RawBody] parameters");
        }
    }
}