using FeatureToggles.Domain;
using FeatureToggles.WebApi.Config;
using FeatureToggles.WebApi.FeatureToggles;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FeatureToggles.WebApi
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                         .SetBasePath(env.ContentRootPath)
                         .AddJsonFile("appsettings.json", true, true)
                         .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                         .AddEnvironmentVariables("FEATURE_TOGGLES_");

            _configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.Configure<FeatureTogglesConfigurationSection>(_configuration.GetSection("FeatureToggles"));
            services.AddSingleton<IFeatureToggleConfigurationReader, FeatureToggleEnvironmentVariablesReader>();
            // services.AddSingleton<IFeatureToggleConfigurationReader, FeatureToggleConfigFileReader>();
            services.AddSingleton<SecondFeatureBusinessLogicClass>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
