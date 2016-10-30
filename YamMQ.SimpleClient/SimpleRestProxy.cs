using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using YamMQ.General.Network;
using IRestRequest = YamMQ.General.Network.IRestRequest;
using IRestResponse = YamMQ.General.Network.IRestResponse;

namespace YamMQ.SimpleClient
{
    internal sealed class SimpleRestProxy : IRestProxy
    {
        private SimpleRestProxy()
        {
        }

        public static IRestProxy Instance { get; } = new SimpleRestProxy();

        public IRestResponse Execute(IRestRequest request)
        {
            var restClient = CreateRestClient(request);

            var restSharpRestRequest = ConvertRestRequest(request);

            var restSharpRestResponse = restClient.Execute(restSharpRestRequest);

            var restResponse = ConvertRestResponse(restSharpRestResponse);

            return restResponse;
        }

        public async Task<IRestResponse> ExecuteAsync(IRestRequest request,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var restClient = CreateRestClient(request);

            var restSharpRestRequest = ConvertRestRequest(request);

            var restSharpRestResponse = await restClient.ExecuteTaskAsync(restSharpRestRequest, cancellationToken);

            var restResponse = ConvertRestResponse(restSharpRestResponse);

            return restResponse;
        }

        private static SimpleRestResponse ConvertRestResponse(RestSharp.IRestResponse restSharpRestResponse)
        {
            var headers =
                restSharpRestResponse.Headers.Select(
                    parameter => new SimpleHeader(parameter.Name, parameter.Value.ToString()));

            var restResponse = new SimpleRestResponse(restSharpRestResponse.StatusCode, restSharpRestResponse.Content,
                headers);

            return restResponse;
        }

        private static RestRequest ConvertRestRequest(IRestRequest request)
        {
            var method = ConvertMethod(request.HttpMethod);

            var restSharpRestRequest = new RestRequest
            {
                Method = method,
                Resource = string.Empty
            };

            restSharpRestRequest.AddParameter("application/json", request.RequestBody, ParameterType.RequestBody);

            foreach (var requestHeader in request.Headers)
            {
                restSharpRestRequest.AddHeader(requestHeader.Name, requestHeader.Value);
            }

            return restSharpRestRequest;
        }

        private static RestClient CreateRestClient(IRestRequest request)
        {
            var restClient = new RestClient(request.Url);

            if (request.UseNtlm)
            {
                restClient.Authenticator = new NtlmAuthenticator();
            }

            return restClient;
        }

        // ReSharper disable once CyclomaticComplexity
        private static Method ConvertMethod(HttpMethod httpMethod)
        {
            switch (httpMethod)
            {
                case HttpMethod.Get:
                    return Method.GET;
                case HttpMethod.Post:
                    return Method.POST;
                case HttpMethod.Put:
                    return Method.PUT;
                case HttpMethod.Patch:
                    return Method.PATCH;
                case HttpMethod.Delete:
                    return Method.DELETE;
                default:
                    throw new ArgumentOutOfRangeException(nameof(httpMethod), httpMethod, null);
            }
        }
    }
}