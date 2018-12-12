using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using Utils.DataAccess;
using Tapster.Common.Repositories;
using Tapster.DomainEntities.Entities;

namespace Tapster.DataAccess.Repositories
{
    public class TablesRepository : EfCoreRepository<Table>, ITablesRepository
    {
        public TablesRepository(DbContext context) 
            : base(context)
        {
        }

        public IEnumerable<Table> GetByVenue(Guid venueId)
        {
            return Query.Where(t => t.VenueId == venueId);
        }
    }
}
