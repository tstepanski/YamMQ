using System;
using System.Threading;
using System.Threading.Tasks;

namespace YamMQ.Services
{
    public interface IMessageService
    {
        Task<Guid> CreateMessage(string serializedMessage,
            CancellationToken cancellationToken = default(CancellationToken));
    }

    internal sealed class MessageService : IMessageService
    {
        public Task<Guid> CreateMessage(string serializedMessage,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }
    }
}