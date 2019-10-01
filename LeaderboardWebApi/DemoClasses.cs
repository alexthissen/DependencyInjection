using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaderboardWebApi
{
    public interface IThing
    {
        void Trigger();
    }

    public class Thing : IThing
    {
        public Thing(IHttpContextAccessor accessor)
        {

        }
        public void Trigger() { }
    }

    public class OuterThing
    {
        private readonly IThing innerThing;

        public OuterThing(IThing innerThing)
        {
            this.innerThing = innerThing;
        }
    }

    public class RecursiveThing : IThing
    {
        public RecursiveThing(IThing once) { }
        public void Trigger() { }
    }

    public static class ThingsServiceCollectionExtensions
    {
        public static IServiceCollection AddThings(this IServiceCollection services)
        {
            return services.AddScoped<IThing, Thing>();
        }
    }
}
