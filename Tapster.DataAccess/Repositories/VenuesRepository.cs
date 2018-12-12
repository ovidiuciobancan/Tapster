using Microsoft.EntityFrameworkCore;

using Utils.DataAccess;
using Tapster.Common.Repositories;
using Tapster.DomainEntities.Entities;

namespace Tapster.DataAccess.Repositories
{
    public class VenuesRepository : EfCoreRepository<Venue>, IVenuesRepository
    {
        public VenuesRepository(DbContext context) 
            : base(context)
        {
        }
    }
}
