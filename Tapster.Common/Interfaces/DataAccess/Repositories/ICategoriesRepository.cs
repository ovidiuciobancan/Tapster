using System;
using System.Collections.Generic;

using Utils.DataAccess.Interfaces;
using Tapster.DomainEntities.Entities;

namespace Tapster.Common.Repositories
{
    public interface ICategoriesRepository : IRepository<Category>
    {
        IEnumerable<Category> GetByVenue(Guid venueId);
    }
}