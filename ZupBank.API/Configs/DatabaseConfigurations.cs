using ZupBank.Application.AppSettings;
using ZupBank.Data.Data.Connectors;
using ZupBank.Data.Data.Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ZupBank.API.Configs
{
    public static class DatabaseConfigurations
    {
        public static void AddDatabase(this IServiceCollection services, DataAppSettings dataAppSettings)
        {
            services.AddDbContext<PerContext>(o => o.UseSqlServer(dataAppSettings.ConnectionStrings.SqlCNN));
            services.AddScoped<PerContext>();
            services.AddScoped<DbConnectionPerSQL>();

            services.AddSingleton<IDapperColumnMapper, DapperColumnMapper>();
        }
    }
}
