using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using MediatR.Infrastructure.Api;
using Microsoft.Extensions.Logging;

namespace MediatR.Consumer
{
    public sealed class ConsumerModule : IModule
    {
        private readonly ILogger _logger;

        public ConsumerModule()
        {
            _logger = ModuleLoggerFactory.Create<ConsumerModule>();

        }
        public Task LoadAsync(ContainerBuilder builder)
        {
            _logger.LogInformation("Loading consumer module.");
            var mediatrOpenTypes = new[]
            {
                typeof(IRequestHandler<,>) 
                //,
                // typeof(IRequestExceptionHandler<,,>),
                // typeof(IRequestExceptionAction<,>),
                // typeof(INotificationHandler<>),
                // typeof(IStreamRequestHandler<,>)
            };
            
            foreach (var mediatrOpenType in mediatrOpenTypes)
            {
                builder
                    .RegisterAssemblyTypes(typeof(ConsumerModule).GetTypeInfo().Assembly)
                    .AsClosedTypesOf(mediatrOpenType)
                    .AsImplementedInterfaces();
            }
            
            return Task.CompletedTask;
        }
    }
}