using System.Collections.Generic;

namespace CustomDIWebAPI.Infrastructure
{
    public class Thing : IThing
    {
        public IEnumerable<string> ProduceValues()
        {
            return new [] { "value1", "value2" };
        }
    }
}
