using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Utils.DataAccess.Interfaces;
using Utils.EntityFrameworkCore.Extensions;

namespace Utils.DataAccess
{
    public class EfCoreRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, new()
    {
        protected DbContext Context { get; }
        public EfCoreRepository(DbContext context)
        {
            Context = context ?? throw new ArgumentException("Context cannot be null");
        }

        public virtual IQueryable<TEntity> Query => Context.Set<TEntity>().AsQueryable();
        public virtual TEntity Get(params object[] key)
        {
            return Context.Set<TEntity>().Find(key);
        }
        public virtual void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }
        public virtual void AddRange(List<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
        }
        public virtual void Update(TEntity entity)
        {
            // No implementation
        }
        public virtual void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Attach(entity);
            Context.Set<TEntity>().Remove(entity);
        }
        public virtual void Remove(params object[] key)
        {
            var stub = Context
                .PrimaryKey<TEntity>()
                .Stub<TEntity>(key);

            Context.Set<TEntity>().Attach(stub);
            Context.Set<TEntity>().Remove(stub);
        }
        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }
    }
}