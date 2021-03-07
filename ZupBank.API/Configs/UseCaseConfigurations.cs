using ZupBank.Application.UseCases;
using ZupBank.Application.UseCases.Gateways;
using Microsoft.Extensions.DependencyInjection;

namespace ZupBank.API.Configs
{
    public static class UseCaseConfigurations
    {
        public static void AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<IAddPersonUseCase, AddPersonUseCase>();
            services.AddScoped<IGetPersonUseCase, GetPersonUseCase>();
        }
    }
}
