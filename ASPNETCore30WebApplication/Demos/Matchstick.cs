using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore30WebApplication.Demos
{
    public interface IOnce
    {
        void Burn();
    }

    public class Matchstick : IOnce
    {
        private bool AlreadyBurnt = false;
        public void Burn()
        {
            if (AlreadyBurnt) throw new InvalidOperationException();
            AlreadyBurnt = true;
        }
    }

    public class SelfLightingMatchstick : IOnce
    {
        public SelfLightingMatchstick(IOnce once) { }
        public void Burn() { }
    }
}
