using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using Utils.DataAccess;
using Tapster.Common.Repositories;
using Tapster.DomainEntities.Entities;

namespace Tapster.DataAccess.Repositories
{
    public class ProductsRepository : EfCoreRepository<Product>, IProductsRepository
    {
        public ProductsRepository(DbContext context) : base(context) { }

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