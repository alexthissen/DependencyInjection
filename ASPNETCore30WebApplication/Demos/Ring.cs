using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore30WebApplication.Demos
{
    public interface IRing
    {
        bool CanIRuleThemAll();
    }

    public class TheOneRing : IRing
    {
        private static int NumberOfRings = 0;
        public TheOneRing()
        {
            if (NumberOfRings > 0) throw new InvalidOperationException("There can be only one ring");
            NumberOfRings++;
        }
        public bool CanIRuleThemAll() => true;
    }
}
