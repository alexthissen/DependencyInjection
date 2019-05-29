using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SampleContainer;

namespace GenericHostWorkerApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var isService = !(Debugger.IsAttached || args.Contains("--console"));

            await CreateCustomHostBuilder(args).Build().RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddThings();
                    services.AddHostedService<Worker>();
                });


        public static IHostBuilder CreateCustomHostBuilder(string[] args)
        {
            var host = new HostBuilder();
            host
                .ConfigureLogging((hostingContext, logging) => 
                {
                    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                    logging.AddConsole();
                    logging.AddDebug();
                    logging.AddEventSourceLogger();
                })
                .UseServiceProviderFactory<SampleServiceContainerBuilder>(new SampleServiceContainerFactory())
                .ConfigureContainer<SampleServiceContainerBuilder>((hostContext, container) =>
                {
                    Console.WriteLine(hostContext.HostingEnvironment.ApplicationName);
                })
                .ConfigureServices((context, services) =>
                {
                    // Other services
                    services.AddHealthChecks();
                    services.AddThings();
                    
                    // Hosted background services (IHostedService and BackgroundService)
                    services.AddHostedService<Worker>();
                })
                .UseConsoleLifetime(options => options.SuppressStatusMessages = false);

            return host;

        }

    }
}
