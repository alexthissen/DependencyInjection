using LightInject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaderboardWebApi
{
    public class CompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            if (serviceRegistry == null)
                throw new ArgumentNullException(nameof(serviceRegistry));

            serviceRegistry.Register<IHighScoreRepository, HighScoreRepository>(new PerScopeLifetime());
        }
    }

    public class HighScoreRepository: IHighScoreRepository
    {
    }

    public interface IHighScoreRepository
    {
    }
}
