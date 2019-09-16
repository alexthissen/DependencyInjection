using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HighScoreWorkerService
{
    public interface IHighScoreService
    {
        void HandleScore();
    }

    public class HighScoreService : IHighScoreService
    {
        public void HandleScore()
        {
            throw new NotImplementedException();
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
