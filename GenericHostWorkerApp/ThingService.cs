using System.Collections.Generic;

namespace GenericHostWorkerApp
{
    public class ThingService : IThingService
    {
        public IEnumerable<string> ProduceValues()
        {
            return new [] { "value1", "value2" };
        }
    }
}
