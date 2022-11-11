using System;
using System.Threading.Tasks;
using MediatR.Infrastructure.Core;
using Microsoft.Extensions.Logging;
using Serilog;

namespace MediatR.Deployment
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var loggerFactory = new LoggerFactory();
            var loggerConfig = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
            
            loggerFactory.AddSerilog(loggerConfig);

            var logger = loggerFactory.CreateLogger<Program>();
            
            logger.LogInformation("Starting application worker.");

            var applicationWorker = new ApplicationWorker();

            await applicationWorker.StartApplicationAsync();
            
            logger.LogInformation("Finished application execution. Press a key to finish.");

            Console.ReadLine();
        }
    }
}
