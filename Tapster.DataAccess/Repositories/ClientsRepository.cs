using Microsoft.EntityFrameworkCore;

using Utils.DataAccess;
using Tapster.Common.Repositories;
using Tapster.DomainEntities.Entities;

namespace Tapster.DataAccess.Repositories
{
    public class ClientsRepository : EfCoreRepository<Client>, IClientsRepository
    {
        public ClientsRepository(DbContext context)
            : base(context)
        {
        }
    }
}