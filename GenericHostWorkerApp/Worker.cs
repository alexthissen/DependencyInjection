using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GenericHostWorkerApp
{
    public class Worker : BackgroundService
    {
        private readonly IServiceScopeFactory serviceScopeFactory;
        private readonly ILogger<Worker> logger;

        public Worker(IServiceScopeFactory serviceScopeFactory, ILogger<Worker> logger)
        {
            this.serviceScopeFactory = serviceScopeFactory;
            this.logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            logger.LogInformation($"Started work in ExecuteAsync at: {DateTime.Now}");

            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = serviceScopeFactory.CreateScope())
                {
                    IThingService scoped = scope.ServiceProvider.GetRequiredService<IThingService>();
                    await MakeThingDoWork(scoped);
                }

                await Task.Delay(1000, stoppingToken);
            }
        }

        private Task<IEnumerable<string>> MakeThingDoWork(IThingService service)
        {
            logger.LogInformation($"Worker running at: {DateTime.Now}");
            return Task.FromResult(service.ProduceValues());
        }

    }
}
