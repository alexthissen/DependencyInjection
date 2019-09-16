using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HighScoreWorkerService
{
    public class Worker : BackgroundService
    {
        private readonly IServiceScopeFactory serviceScopeFactory;
        private readonly ILogger<Worker> logger;

        public Worker(ILogger<Worker> logger, IServiceScopeFactory serviceScopeFactory)
        {
            this.serviceScopeFactory = serviceScopeFactory;
            this.logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                
                using (var scope = serviceScopeFactory.CreateScope())
                {
                    IHighScoreService scoped = scope.ServiceProvider.GetRequiredService<IHighScoreService>();
                    await HandleHighScore(scoped);
                }
                await Task.Delay(1000, stoppingToken);
            }
        }

        private Task HandleHighScore(IHighScoreService scoped)
        {
            // Do handling here

            return Task.CompletedTask;
        }
    }
}