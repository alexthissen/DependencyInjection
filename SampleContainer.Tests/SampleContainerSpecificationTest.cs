using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Specification;
using System;
using Xunit;
using SampleContainer;

namespace SampleContainer.Tests
{
    public class SampleContainerSpecificationTest : DependencyInjectionSpecificationTests
    {
        protected override IServiceProvider CreateServiceProvider(IServiceCollection serviceCollection)
        {
            return new SampleServiceContainerFactory().CreateServiceProvider(new SampleServiceContainerBuilder(serviceCollection));
        }
    }
}
