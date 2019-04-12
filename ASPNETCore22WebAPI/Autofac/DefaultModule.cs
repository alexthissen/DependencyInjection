using Autofac;
using ASPNETCore22WebAPI.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore22WebAPI.Autofac
{
    public class DefaultModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Thing>().As<IThing>();
        }
    }
}
