using System.Linq;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using Utils.EntityFrameworkCore.Extensions;

namespace Tapster.IdentityServer.Data.Seeders
{
    public class IdentityResourcesSeeder : ISeeder<ConfigurationDbContext>
    {
        public void Seed(ConfigurationDbContext context)
        {
            if(!context.Clients.Any())
            {
                var identityResources = Config.GetIdentityResources()
                    .Select(c => c.ToEntity())
                    .ToList();

                context.IdentityResources.AddRange(identityResources);
                context.SaveChanges();
            }
        }
    }
}
