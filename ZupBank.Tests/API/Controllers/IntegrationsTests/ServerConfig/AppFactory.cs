using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using ZupBank.Application.Services;
using ZupBank.Domain.Repositories;
using ZupBank.Tests.API.Controllers.IntegrationsTests.Sandbok;

namespace ZupBank.Tests.API.Controllers.IntegrationsTests.ServerConfig
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TStartup"></typeparam>
    public class AppFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddScoped<IPostService, PostServiceMock>();
                services.AddScoped<IPersonRepository, PersonRepositoryMock>();
            });
        }
    }
}
