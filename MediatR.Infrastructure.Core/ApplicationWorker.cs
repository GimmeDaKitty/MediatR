using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using MediatR.Consumer;
using MediatR.Infrastructure.Api;
using MediatR.Publisher;
using Microsoft.Extensions.Logging;
using Serilog;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace MediatR.Infrastructure.Core
{
    public sealed class ApplicationWorker
    {
        private ILogger _logger;
        public async Task StartApplicationAsync()
        {
            var builder = new ContainerBuilder();

            var loggerFactory = new LoggerFactory();
            var loggerConfig = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
            loggerFactory.AddSerilog(loggerConfig);

            _logger = loggerFactory.CreateLogger(nameof(ApplicationWorker));

            builder.RegisterInstance(loggerFactory)
                .As<ILoggerFactory>()
                .SingleInstance();
            
            builder.RegisterGeneric(typeof(Logger<>))
                .As(typeof(ILogger<>))
                .SingleInstance();

            builder.RegisterAssemblyTypes(typeof(IMediator)
                .GetTypeInfo().Assembly)
                .AsImplementedInterfaces();

            await LoadModules(builder);
            
            builder.Register<ServiceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });
            var container = builder.Build();
            
            _logger.LogInformation("Starting application execution");
            
            var publisher = container.Resolve<IMessagePublisher>();

            await publisher.Publish("Yoooo");
        }

        private IEnumerable<IModule> GetModules()
        {
            yield return new ConsumerModule();
            yield return new PublisherModule();
        }

        private async Task LoadModules(ContainerBuilder builder)
        {
            var modules = GetModules().ToArray();

            foreach (var module in modules)
            {
                _logger.LogInformation($"Loading in module: {module.GetType().Name}");
                await module.LoadAsync(builder);
            }
        }
    }
}