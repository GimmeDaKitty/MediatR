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
            
            ModuleMediatRRegistrations.RegisterMediatRServices<ConsumerModule>(builder);

            return Task.CompletedTask;
        }
    }
}