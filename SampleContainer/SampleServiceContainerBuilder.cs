using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleContainer
{
    public class SampleServiceContainerBuilder
    {
        IServiceCollection services;

        public SampleServiceContainerBuilder(IServiceCollection services)
        {
            this.services = services;
        }

        public IServiceProvider Build() =>
            new DefaultServiceProviderFactory().CreateServiceProvider(services);

        public void AddThings()
        {
            //services.AddSingleton<IThingService, ThingService>();
        }
    }
}
