using System.Linq;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using Utils.EntityFrameworkCore.Extensions;

namespace Tapster.IdentityServer.Data.Seeders
{
    public class ClientsSeeder : ISeeder<ConfigurationDbContext>
    {
        public void Seed(ConfigurationDbContext context)
        {
            if(!context.Clients.Any())
            {
                var clients = Config.GetClients()
                    .Select(c => c.ToEntity())
                    .ToList();

                context.Clients.AddRange(clients);
                context.SaveChanges();
            }
        }
    }
}
