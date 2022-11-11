
using System.Threading.Tasks;
using MediatR.Infrastructure.Api.Messages;
using Microsoft.Extensions.Logging;

namespace MediatR.Publisher
{
    public sealed class MessagePublisher : IMessagePublisher
    {
        private readonly ILogger<MessagePublisher> _logger;
        private readonly IMediator _mediator;

        public MessagePublisher(ILogger<MessagePublisher> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public async Task Publish(string messageText)
        {
            _logger.LogWarning($"Sending request with message {messageText}");
            var request = new RequestMessage(messageText);
            var response = await _mediator.Send(request);
            _logger.LogWarning($"Received response was: {response.Text}");
        }
    }
}