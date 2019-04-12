using ASPNETCore22WebAPI.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETCore22WebAPI.IntegrationTests
{
    public class MockThing : IThing
    {
        public IEnumerable<string> ProduceValues()
        {
            return new[] { "mock1", "mock2", "mock3" };
        }
    }

    public class ServiceContractIntegrationTest
    {
        TestServer testServer;
        HttpClient httpClient;

        [TestInitialize]
        public void Initialize()
        {
            var builder = new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<Startup>()
                .ConfigureTestServices(services =>
                {
                    services.AddTransient<IThing, MockThing>();
                });

            // Create test stack
            testServer = new TestServer(builder);
            httpClient = testServer.CreateClient();
        }

        [TestMethod]
        public async Task GetReturns200OK()
        {
            // Act
            var response = await httpClient.GetAsync("/api/values");

            // Assert
            response.EnsureSuccessStatusCode();
            string responseHtml = await response.Content.ReadAsStringAsync();
            Assert.IsTrue(responseHtml.Contains("mock1"));
        }

    }
}
