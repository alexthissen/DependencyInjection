using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore30WebApplication.Demos
{
    public interface IThing
    {
        bool Go();
    }

    public class Thing : IThing
    {
        private static int NumberOfThings = 0;
        public Thing()
        {
            if (NumberOfThings > 0) throw new InvalidOperationException("There can be only one thing");
            NumberOfThings++;
        }
        public bool Go() => true;
    }
}
