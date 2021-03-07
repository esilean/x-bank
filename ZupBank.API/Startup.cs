using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ZupBank.API.Configs;
using ZupBank.API.Filters;
using ZupBank.Application.AppSettings;

namespace ZupBank.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var dataAppSettings = new DataAppSettings();
            services.AddSecrets(Configuration);
            Configuration.Bind(dataAppSettings);
            services.AddSingleton(dataAppSettings);

            services.AddBase();
            services.AddUseCases();
            services.AddHttpServices(dataAppSettings);
            services.AddDatabase(dataAppSettings);
            services.AddRepositories();

            services.AddControllers(opts =>
            {
                opts.Filters.Add<NotificationFilter>();
            })
            .AddNewtonsoftJson();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
