using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HighScoreWorkerService
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
                .UseEnvironment("Development")
                .UseDefaultServiceProvider((context, options) =>
                {
                    options.ValidateScopes = context.HostingEnvironment.IsDevelopment();
                    options.ValidateOnBuild = true;
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddDbContext<WorkerServiceDbContext>(options =>
                    {
                        options.UseInMemoryDatabase(databaseName: "workerservice");
                    });
                    services.AddTransient<IHighScoreService, HighScoreService>();
                    //services.AddHighScores();

                    //services.AddScoped<IThing, Thing>();
                    //services.AddSingleton<OuterThing>();
                    //services.AddScoped<IThing, RecursiveThing>();

                    // Hosted background services (IHostedService and BackgroundService)
                    services.AddHostedService<Worker>();
                })
                .UseConsoleLifetime(options => options.SuppressStatusMessages = false);
    }

    public class WorkerServiceDbContext: DbContext
    {
        public WorkerServiceDbContext(DbContextOptions<WorkerServiceDbContext> options)
            : base(options)
        {
        }
    }
}
