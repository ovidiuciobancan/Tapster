using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using Utils.DataAccess;
using Tapster.Common.Repositories;
using Tapster.DomainEntities.Entities;

namespace Tapster.DataAccess.Repositories
{
    public class CategoriesRepository : EfCoreRepository<Category>, ICategoriesRepository
    {
        public CategoriesRepository(DbContext context) : base(context) { }

        public IEnumerable<Category> GetByVenue(Guid venueId)
        {
            return Context.Set<Category>()
                .Where(c => c.VenueId == venueId)
                .Include(c => c.SubCategories)
                .Include(c => c.Products);
        }
 
        public void AddCategory(Category entity)
        {
            Context.Set<Category>().Add(entity);
            Context.Set<Product>().AddRange(entity.Products);
            entity.SubCategories.ToList().ForEach(p => AddCategory(p));
        }

        public void AddCategories(List<Category> entities)
        {
            entities.ForEach(p => AddCategory(p));
        }

    }
}