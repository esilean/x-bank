using System.Threading.Tasks;
using Xunit;
using ZupBank.API;
using ZupBank.Tests.API.Controllers.IntegrationsTests.ServerConfig;

namespace ZupBank.Tests.API.Controllers.IntegrationsTests
{
    [Collection(nameof(IntegrationTestsFixtureCollection))]
    public class PersonsControllerMockTests : IClassFixture<AppFactory<Startup>>
    {
        private readonly IntegrationTestsFixture<Startup> _testsFixture;

        public PersonsControllerMockTests(IntegrationTestsFixture<Startup> testsFixture)
        {
            _testsFixture = testsFixture;

        }

        [Fact]
        public async Task PersonsMock_OK()
        {
            //Arrange
            //Act
            var response = await _testsFixture.Client.GetAsync("/persons");

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }

    }
}
