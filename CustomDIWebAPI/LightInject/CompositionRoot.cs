using CustomDIWebAPI.Infrastructure;
using LightInject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomDIWebAPI.LightInject
{
    public class CompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<IThing, Thing>(new PerRequestLifeTime());
        }
    }
}
