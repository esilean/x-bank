using ZupBank.Application.AppSettings;
using ZupBank.Application.Services;
using ZupBank.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ZupBank.API.Configs
{
    public static class HttpConfigurations
    {
        public static void AddHttpServices(this IServiceCollection services, DataAppSettings dataAppSettings)
        {
            services.AddScoped<IPostService, PostService>();

            foreach (var client in dataAppSettings.HttpClients)
            {
                services.AddHttpClient(client.Name, o =>
                {
                    o.BaseAddress = new Uri(client.BaseAddress);
                });
            }
        }

    }
}
