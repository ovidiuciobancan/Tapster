using Microsoft.EntityFrameworkCore;

using Utils.DataAccess;
using Tapster.Common.Repositories;
using Tapster.DomainEntities.Entities;

namespace Tapster.DataAccess.Repositories
{
    public class WaitersRepository : EfCoreRepository<Waiter>, IWaitersRepository
    {
        public WaitersRepository(DbContext context)
            : base(context)
        {
        }
    }
}