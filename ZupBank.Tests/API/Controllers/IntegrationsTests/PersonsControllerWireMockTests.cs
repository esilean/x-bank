using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using Xunit;
using ZupBank.API;
using ZupBank.Tests.API.Controllers.IntegrationsTests.ServerConfig;

namespace ZupBank.Tests.API.Controllers.IntegrationsTests
{
    public class PersonsControllerWireMockTests : TestBase
    {
        private WireMockServer _mockServerSearchEngine;

        public PersonsControllerWireMockTests(WebApplicationFactory<Startup> factory)
                                                    : base(factory, 5347, false) { }

        [Fact]
        public async Task PersonsWireMock_OK()
        {
            //Arrange
            var postsJson = File.ReadAllText(@$"API\Controllers\IntegrationsTests\Sandbox\Data\posts.json");
            SetupStableServer(postsJson);

            //Act
            var response = await HttpClient.GetAsync("/persons");

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());

            var requests =
               _mockServerSearchEngine.LogEntries.Select(l => l.RequestMessage).ToList();
            Assert.Single(requests);
            Assert.Contains($"/typicode/demo/posts", requests.Single().AbsoluteUrl);
        }

        private void SetupStableServer(string response)
        {
            _mockServerSearchEngine
                    .Given(
                            Request.Create().UsingGet())
                    .RespondWith(
                            Response.Create()
                            .WithBody(response)
                            .WithStatusCode(200));
        }

        protected override IConfiguration GetConfiguration()
        {
            _mockServerSearchEngine = WireMockServer.Start();
            var mockUrl = _mockServerSearchEngine.Urls.Single();

            var configuration = base.GetConfiguration();
            configuration["HttpClients:0:BaseAddress"] = mockUrl;

            return configuration;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                _mockServerSearchEngine.Stop();
                _mockServerSearchEngine.Dispose();
            }
        }

    }
}
