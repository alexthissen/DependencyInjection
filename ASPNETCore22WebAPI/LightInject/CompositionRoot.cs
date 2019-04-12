using ASPNETCore22WebAPI.Infrastructure;
using LightInject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore22WebAPI.LightInject
{
    public class CompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<IThing, Thing>();
        }
    }
}
