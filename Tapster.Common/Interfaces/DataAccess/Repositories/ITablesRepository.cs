using System;
using System.Collections.Generic;
using Tapster.DomainEntities.Entities;
using Utils.DataAccess.Interfaces;

namespace Tapster.Common.Repositories
{
    public interface ITablesRepository : IRepository<Table>
    {
        IEnumerable<Table> GetByVenue(Guid venueId);
    }
}