using System.Linq;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using Utils.EntityFrameworkCore.Extensions;

namespace Tapster.IdentityServer.Data.Seeders
{
    public class ApiResourcesSeeder : ISeeder<ConfigurationDbContext>
    {
        public void Seed(ConfigurationDbContext context)
        {
            if(!context.Clients.Any())
            {
                var apiResources = Config.GetApiResources()
                    .Select(c => c.ToEntity())
                    .ToList();

                context.ApiResources.AddRange(apiResources);
                context.SaveChanges();
            }
        }
    }
}
