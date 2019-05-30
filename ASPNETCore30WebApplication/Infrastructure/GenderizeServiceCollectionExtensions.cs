using ASPNETCore30WebApplication.Demos;
using Microsoft.AspNetCore.Http;
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
            services.AddSingleton<IThing, Thing>();
            services.AddTransient<IOnceThing, Something>();
            services.AddTransient(typeof(IBag<>), typeof(Cup<>));
            services.AddTransient<IOnceThing, RecursiveSomething>();

            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            return services;
        }
    }
}
