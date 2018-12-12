using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Utils.Extensions
{
    public static class WebHostConfigurationExtensionMethods
    {
        public static IWebHostBuilder ConfigureAppConfig(this IWebHostBuilder builder)
        {
            return builder.ConfigureAppConfiguration((builderContext, config) =>
            {
                IHostingEnvironment env = builderContext.HostingEnvironment;

                config
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
            });
        }
         
    }
}