using System.Collections.Generic;

namespace ASPNETCore22WebAPI.Infrastructure
{
    public class Thing : IThing
    {
        public Thing(IThing thing) { }

        public IEnumerable<string> ProduceValues()
        {
            return new [] { "value1", "value2", "value3" };
        }
    }
}
