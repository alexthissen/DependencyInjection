using Microsoft.AspNetCore.Http;
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

    public class RecursiveThing : IThing
    {
        public RecursiveThing(IThing once) { }
        public void Trigger() { }
    }
}
