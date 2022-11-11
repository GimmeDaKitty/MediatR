using System.Threading.Tasks;
using Autofac;
using MediatR.Infrastructure.Api;
using Microsoft.Extensions.Logging;

namespace MediatR.Publisher
{
    public sealed class PublisherModule : IModule
    {
        private readonly ILogger _logger;
        
        public PublisherModule()
        {
            _logger = ModuleLoggerFactory.Create<PublisherModule>();

        }
        public Task LoadAsync(ContainerBuilder builder)
        {
            _logger.LogInformation("Loading publisher module.");

            ModuleMediatRRegistrations.RegisterMediatRServices<PublisherModule>(builder);

            builder.RegisterType<MessagePublisher>()
                .As<IMessagePublisher>()
                .SingleInstance();
            
            return Task.CompletedTask;
        }
    }
}