using System;
using System.Threading;
using System.Threading.Tasks;
using YamMQ.Client;
using YamMQ.General.Configuration;
using YamMQ.General.Types;

namespace YamMQ.SimpleClient
{
    public sealed class SimpleMessageService : IMessageService
    {
        private readonly IMessageService _underlyingMessageService;

        public SimpleMessageService(Func<IBusConfigurationFactory, IBusApiConfiguration> busApiConfigurationHelper)
        {
            var busApiConfiguration = busApiConfigurationHelper(BusConfigurationFactory.Instance);

            _underlyingMessageService = new MessageService(SimpleSerializer.Instance, SimpleRestProxy.Instance,
                busApiConfiguration);
        }

        public Guid PublishMessage<T>(T message) where T : IMessage => _underlyingMessageService.PublishMessage(message);

        public Task<Guid> PublishMessageAsync<T>(T message,
            CancellationToken cancellationToken = default(CancellationToken)) where T : IMessage
        => _underlyingMessageService.PublishMessageAsync(message, cancellationToken);
    }
}