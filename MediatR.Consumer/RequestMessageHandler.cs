using System.Threading;
using System.Threading.Tasks;
using MediatR.Infrastructure.Api.Messages;
using Microsoft.Extensions.Logging;

namespace MediatR.Consumer
{
    public sealed class RequestMessageHandler : IRequestHandler<RequestMessage, ResponseMessage>
    {
        private readonly ILogger<RequestMessageHandler> _logger;

        public RequestMessageHandler(ILogger<RequestMessageHandler> logger)
        {
            _logger = logger;
        }
        
        public Task<ResponseMessage> Handle(RequestMessage request, CancellationToken cancellationToken)
        {
            _logger.LogWarning($"Returning response to request: '{request.Text}'");
            var response = new ResponseMessage("Suuuuuuuuuuup!!");
            return Task.FromResult(response);
        }
    }
}