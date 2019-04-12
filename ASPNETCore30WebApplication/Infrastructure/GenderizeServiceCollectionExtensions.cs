using ASPNETCore30WebApplication.Demos;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore30WebApplication.Infrastructure
{
    public static class DemosServiceCollectionExtensions
    {
        public static IServiceCollection AddDemos(this IServiceCollection services)
        {
            services.AddSingleton<IRing, TheOneRing>();
            services.AddTransient<IOnce, Matchstick>();
            services.AddTransient(typeof(IBag<>), typeof(Cup<>));
            services.AddTransient<IOnce, SelfLightingMatchstick>();

            return services;
        }
    }
}
