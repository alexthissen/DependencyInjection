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

            await CreateHostBuilder(args).Build().RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddHostedService<Worker>();
                });


        public static IHostBuilder CreateCustomHostBuilder(string[] args)
        {
            var host = new HostBuilder();
            host
                .UseServiceProviderFactory<SampleServiceContainerBuilder>(new SampleServiceContainerFactory())
                .ConfigureContainer<SampleServiceContainerBuilder>((hostContext, container) =>
                {
                    container.AddThings();
                    Console.WriteLine(hostContext.HostingEnvironment.ApplicationName);
                })
                .ConfigureServices((context, services) =>
                {
                    services.AddHealthChecks();
                    services.AddHostedService<Worker>();
                });

            return host;

        }

    }
}
