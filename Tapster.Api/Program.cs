using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Tapster.DataAccess;
using Utils.EntityFrameworkCore.Extensions; 

namespace Tapster.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args)
                .MigrateDb<AppDbContext>()
                .SeedData<AppDbContext>()
                .Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
