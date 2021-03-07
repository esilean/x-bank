using ZupBank.Data.Repositories;
using ZupBank.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ZupBank.API.Configs
{
    public static class RepositoryConfigurations
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPersonRepository, PersonRepository>();
        }
    }
}
