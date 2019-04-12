using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore30WebApplication
{
    public class GenderizeApiOptions
    {
        public string BaseUrl { get; set; }
        public string DeveloperApiKey { get; set; }
        public bool Cache { get; set; }
    }
}
