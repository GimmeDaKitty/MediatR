using Microsoft.Extensions.Logging;
using Serilog;

namespace MediatR.Infrastructure.Api
{
    public static class ModuleLoggerFactory
    {
        /// <summary>
        ///     Creates an instance of a <see cref="Microsoft.Extensions.Logging.ILogger" />
        /// </summary>
        public static ILogger<T> Create<T>() where T : IModule
        {
            var loggerFactory = new LoggerFactory();
            var loggerConfig = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
            loggerFactory.AddSerilog(loggerConfig);

            return loggerFactory.CreateLogger<T>();
        }
    }
}