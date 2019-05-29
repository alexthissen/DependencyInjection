using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericHostWorkerApp
{
    public static class SampleServiceCollectionExtensions
    {
        public static IServiceCollection AddThings(this IServiceCollection services)
        {
            return services.AddSingleton<IThingService, ThingService>();
        }
    }
}
