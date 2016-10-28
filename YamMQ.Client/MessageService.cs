using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using YamMQ.Client.Network;
using YamMQ.General.Configuration;
using YamMQ.General.Exceptions;
using YamMQ.General.Helpers;
using YamMQ.General.Network;
using YamMQ.General.Serialization;
using YamMQ.General.Types;

namespace YamMQ.Client
{
    public sealed class MessageService : IMessageService
    {
        private readonly IBusApiConfiguration _busApiConfiguration;
        private readonly IRestProxy _restProxy;
        private readonly ISerializer _serializer;

        public MessageService(ISerializer serializer, IRestProxy restProxy, IBusApiConfiguration busApiConfiguration)
        {
            _serializer = serializer;
            _restProxy = restProxy;
            _busApiConfiguration = busApiConfiguration;
        }

        public Guid PublishMessage<T>(T message) where T : IMessage => PublishMessageAsync(message).Result;

        public async Task<Guid> PublishMessageAsync<T>(T message,
            CancellationToken cancellationToken = default(CancellationToken)) where T : IMessage
        {
            Guard.ThrowIfNull(message, nameof(message));

            var serializedMessage = _serializer.Serialize(message);

            var createRequest = await CreateRequest(serializedMessage, cancellationToken);

            cancellationToken.ThrowIfCancellationRequested();

            IRestResponse response;

            try
            {
                response = await _restProxy.ExecuteAsync(createRequest, cancellationToken);
            }
            catch (Exception exception)
            {
                throw new UnableToCreateMessageException(@"Error posting to Message Bus API", exception);
            }

            const HttpStatusCode expectedStatusCode = HttpStatusCode.Created;

            var returnedStatusCode = response.HttpStatusCode;

            if (returnedStatusCode != expectedStatusCode)
            {
                throw new UnableToCreateMessageException(
                    $"Unexpected HTTP status code, received {returnedStatusCode}, expected {expectedStatusCode}.");
            }

            var createdMessageId = Guid.Parse(response.ResponseBody);

            return createdMessageId;
        }

        private async Task<IRestRequest> CreateRequest(string serializedMessage, CancellationToken cancellationToken)
        {
            var apiSecurityConfiguration = _busApiConfiguration.SecurityConfiguration;

            var useNtlm = apiSecurityConfiguration is INtlmBusApiSecurity;

            IEnumerable<IHeader> headers = null;

            var otherAsOAuthBusApiSecurity = apiSecurityConfiguration as IOAuthBusApiSecurity;

            if (otherAsOAuthBusApiSecurity != null)
            {
                var authorizationHeader =
                    await otherAsOAuthBusApiSecurity.GetNewOAuthTokenHeaderAsync(cancellationToken);

                headers = new[] {authorizationHeader};
            }

            return new PostMessageRequest(_busApiConfiguration.Url, serializedMessage, headers, useNtlm);
        }
    }
}