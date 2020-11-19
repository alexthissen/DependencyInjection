using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace HighScoreWorkerService
{
    public interface IHighScoreService
    {
        void HandleScore();
    }

    public class HighScoreService : IHighScoreService, IDisposable
    {
        private readonly ILogger<HighScoreService> logger;

        public HighScoreService(ILogger<HighScoreService> logger)
        {
            this.logger = logger;
        }

        public void Dispose() 
        { }

        public void HandleScore()
        {
            logger.LogInformation("Score has been handled");
        }
    }

    public static class HighScoreServiceCollectionExtensions
    {
        public static IServiceCollection AddHighScores(this IServiceCollection services)
        {
            return services.AddSingleton<IHighScoreService, HighScoreService>();
        }
    }

}
