using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using System.Linq;
using Tapster.IdentityServer.Data;
using Utils.EntityFrameworkCore.Extensions;

namespace Tapster.IdentityServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
             BuildWebHost(args)
                .MigrateDb<ApplicationDbContext>()
                .MigrateDb<PersistedGrantDbContext>()
                .MigrateDb<ConfigurationDbContext>()
                .SeedData<ConfigurationDbContext>()
                .SeedData<ApplicationDbContext>()
                .Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                    .UseStartup<Startup>()
                    .UseSerilog((context, configuration) =>
                    {
                        configuration
                            .MinimumLevel.Debug()
                            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                            .MinimumLevel.Override("System", LogEventLevel.Warning)
                            .MinimumLevel.Override("Microsoft.AspNetCore.Authentication", LogEventLevel.Information)
                            .Enrich.FromLogContext()
                            .WriteTo.File(@"identityserver4_log.txt")
                            .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}", theme: AnsiConsoleTheme.Literate);
                    })
                    .Build();
        }
    }
}
