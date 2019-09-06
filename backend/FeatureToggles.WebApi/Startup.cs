using FeatureToggles.Domain;
using FeatureToggles.WebApi.Config;
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

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            // services.AddCors(
            //     options =>
            //     {
            //         options.AddPolicy(
            //             options.DefaultPolicyName,
            //             builder =>
            //                 builder
            //                    .AllowAnyOrigin()
            //                    .AllowAnyMethod()
            //                    .AllowAnyHeader()
            //         );
            //     }
            // );
            services.Configure<FeatureToggleOptions>(_configuration.GetSection("FeatureToggles"));
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

            app.UseCors(c => c.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseMvc();
            // app.UseCors();
        }
    }
}
