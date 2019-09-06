using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace FeatureToggles.WebApi
{
    public class Program
    {
        public static void Main(string[] args) => CreateWebHostBuilder(args).Build().Run();

        private static IWebHostBuilder CreateWebHostBuilder(string[] args)
            => WebHost.CreateDefaultBuilder(args)
                      .ConfigureAppConfiguration(
                           config =>
                           {
                               config.AddSystemsManager(
                                   configureSource =>
                                   {
                                       configureSource.Path = "/FeatureToggleDemo";
                                       configureSource.ReloadAfter = TimeSpan.FromMinutes(5);
                                   }
                               );
                           }
                       )
                      .UseStartup<Startup>();
    }
}
