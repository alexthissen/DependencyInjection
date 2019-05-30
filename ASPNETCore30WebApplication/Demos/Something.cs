using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore30WebApplication.Demos
{
    public interface IOnceThing
    {
        void Trigger();
    }

    public class Something : IOnceThing
    {
        private bool AlreadyTriggered = false;

        public void Trigger()
        {
            if (AlreadyTriggered) throw new InvalidOperationException();
            AlreadyTriggered = true;
        }
    }

    public class RecursiveSomething : IOnceThing
    {
        public RecursiveSomething(IOnceThing once) { }
        public void Trigger() { }
    }
}
