
namespace MediatR.Infrastructure.Api.Messages
{
    public sealed class RequestMessage : IRequest<ResponseMessage>
    {
        public RequestMessage(string text)
        {
            Text = text;
        }
        public string Text { get; }
    }
}