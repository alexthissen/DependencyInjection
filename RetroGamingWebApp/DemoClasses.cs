using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetroGamingWebApp
{
    public interface IThing
    {
        void Trigger();
    }

    public class RecursiveThing : IThing
    {
        public RecursiveThing(IThing once) { }
        public void Trigger() { }
    }
}
