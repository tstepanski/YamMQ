using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using YamMQ.Api.Helpers;
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

        [HttpPost, Route("Publish")]
        public Task<Guid> CreateMessage([RawBody] string serializedMessage, CancellationToken cancellationToken)
        {
            return _messageService.CreateMessage(serializedMessage, cancellationToken);
        }
    }
}