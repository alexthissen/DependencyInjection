using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomDIWebAPI.Infrastructure
{
    public interface IThing
    {
        IEnumerable<string> ProduceValues();
    }

    public class Thing : IThing
    {
        public IEnumerable<string> ProduceValues()
        {
            return new [] { "value1", "value2" };
        }
    }
}
