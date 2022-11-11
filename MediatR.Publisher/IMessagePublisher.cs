
using System.Threading.Tasks;

namespace MediatR.Publisher
{
    public interface IMessagePublisher
    {
        Task Publish(string messageText);
    }
}