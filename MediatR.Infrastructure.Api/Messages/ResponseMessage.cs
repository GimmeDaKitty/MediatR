namespace MediatR.Infrastructure.Api.Messages
{
    public sealed class ResponseMessage
    {
        public ResponseMessage(string text)
        {
            Text = text;
        }
        public string Text { get; }
    }
}