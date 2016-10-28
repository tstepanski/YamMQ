using System;
using System.Threading;
using System.Threading.Tasks;
using YamMQ.General.Types;

namespace YamMQ.Client
{
    public interface IMessageService
    {
        Guid PublishMessage<T>(T message) where T : IMessage;

        Task<Guid> PublishMessageAsync<T>(T message, CancellationToken cancellationToken = default(CancellationToken))
            where T : IMessage;
    }
}