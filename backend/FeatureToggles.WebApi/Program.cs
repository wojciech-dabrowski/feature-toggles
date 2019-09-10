using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace FeatureToggles.WebApi
{
    public static class Program
    {
        public static void Main(string[] args) => CreateWebHostBuilder(args).Build().Run();

        private static IWebHostBuilder CreateWebHostBuilder(string[] args)
            => WebHost.CreateDefaultBuilder(args)
                      .ConfigureAppConfiguration(ConfigureAppConfiguration)
                      .UseStartup<Startup>();

        private static void ConfigureAppConfiguration(
            WebHostBuilderContext context,
            IConfigurationBuilder config)
        {
            if (!context.HostingEnvironment.IsEnvironment(LocalEnvironment.Name))
            {
                var envName = context.HostingEnvironment.EnvironmentName;

                config.AddSystemsManager(
                    configureSource =>
                    {
                        configureSource.Path = $"/FeatureToggleDemo/{envName}";
                        configureSource.ReloadAfter = TimeSpan.FromMinutes(5);
                    }
                );
            }
        }
    }
}
