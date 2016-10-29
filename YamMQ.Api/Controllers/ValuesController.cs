using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using YamMQ.Services;

namespace YamMQ.Api.Controllers
{
    [RoutePrefix("Messages")]
    public sealed class MessageController : ApiController
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public Task<Guid> CreateMessage([FromBody] string serializedMessage, CancellationToken cancellationToken)
        {
            return _messageService.CreateMessage(serializedMessage, cancellationToken);
        }
    }
}