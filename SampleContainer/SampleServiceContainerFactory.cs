using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleContainer
{
    public class SampleServiceContainerFactory :
            IServiceProviderFactory<SampleServiceContainerBuilder>
    {
        public SampleServiceContainerBuilder CreateBuilder(IServiceCollection services)
        {
            return new SampleServiceContainerBuilder(services);
        }

        public IServiceProvider CreateServiceProvider(SampleServiceContainerBuilder containerBuilder)
        {
            return containerBuilder.Build();
        }
    }
}
