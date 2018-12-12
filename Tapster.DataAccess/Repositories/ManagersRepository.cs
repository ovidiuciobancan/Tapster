using Microsoft.EntityFrameworkCore;

using Utils.DataAccess;
using Tapster.Common.Repositories;
using Tapster.DomainEntities.Entities;

namespace Tapster.DataAccess.Repositories
{
    public class ManagersRepository : EfCoreRepository<Manager>, IManagersRepository
    {
        public ManagersRepository(DbContext context) 
            : base(context)
        {
        }
    }
}
