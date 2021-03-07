using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using ZupBank.Domain.Core.Notifications;

namespace ZupBank.API.Configs
{
    public static class BaseConfigurations
    {
        public static void AddBase(this IServiceCollection services)
        {
            services.AddScoped<NotificationContext>();
        }

        public static void AddSecrets(this IServiceCollection _, IConfiguration configuration)
        {
            var secretsJson = File.ReadAllText(@"appsecrets.json");

            var secrets = JsonConvert.DeserializeObject<IDictionary<string, string>>(secretsJson);

            foreach (var secret in secrets)
            {
                configuration[secret.Key] = configuration[secret.Key]?.Replace(secret.Value, Environment.GetEnvironmentVariable(secret.Value));
            }
        }
    }
}
