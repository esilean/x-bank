using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using Xunit;
using ZupBank.API;
using ZupBank.Domain.Repositories;
using ZupBank.Tests.API.Controllers.IntegrationsTests.Sandbok;

namespace ZupBank.Tests.API.Controllers.IntegrationsTests.ServerConfig
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class TestBase : IDisposable, IClassFixture<WebApplicationFactory<Startup>>
    {
        protected readonly HttpClient HttpClient;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="factory"></param>
        /// <param name="portNumber"></param>
        /// <param name="useHttps"></param>
        public TestBase(WebApplicationFactory<Startup> factory, int portNumber, bool useHttps)
        {
            string afterHttp = useHttps ? "s" : "";
            HttpClient = factory.WithWebHostBuilder(whb =>
            {
                whb.ConfigureAppConfiguration((context, configbuilder) =>
                {
                    configbuilder.AddConfiguration(GetConfiguration());
                });

                whb.ConfigureServices(services =>
                {
                    services.AddScoped<IPersonRepository, PersonRepositoryMock>();
                });
            })
               .CreateClient(new WebApplicationFactoryClientOptions
               {
                   BaseAddress = new Uri($"http{afterHttp}://localhost:{portNumber}")
               });
        }

        protected virtual IConfiguration GetConfiguration()
        {
            var configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.test.json")
                    .Build();

            return configuration;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                HttpClient.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
