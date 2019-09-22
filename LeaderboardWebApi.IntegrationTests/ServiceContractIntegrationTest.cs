using LightInject.Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;

namespace LeaderboardWebApi.IntegrationTests
{
    [TestClass]
    public class ServiceContractIntegrationTest
    {
        TestServer testServer;
        HttpClient httpClient;

        [TestInitialize]
        public void Initialize()
        {
            var builder = new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup(typeof(Startup).GetTypeInfo().Assembly.GetName().Name)
                .UseLightInject()
                .UseEnvironment("Test")
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
            var response = await httpClient.GetAsync("/api/v1/leaderboard");

            // Assert
            response.EnsureSuccessStatusCode();
            string responseHtml = await response.Content.ReadAsStringAsync();
            Assert.IsTrue(responseHtml.Contains("mock1"));
        }
    }

    public class MockThing : IThing
    {
        public void Trigger() { }
    }
}
