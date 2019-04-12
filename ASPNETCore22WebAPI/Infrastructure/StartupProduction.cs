using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore22WebAPI
{
    public class StartupProduction
    {
        public StartupProduction() { }
        public void ConfigureServices(IServiceCollection services) { }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) { }

    }
}
