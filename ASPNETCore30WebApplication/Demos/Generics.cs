using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore30WebApplication.Demos
{
    public interface IBag<T>
    {
        T Create();
    }

    public class Cup<T> : IBag<T> where T: new()
    {
        public T Create() => new T();
    }
}
