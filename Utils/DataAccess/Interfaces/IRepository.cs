using System.Collections.Generic;
using System.Linq;

namespace Utils.DataAccess.Interfaces
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        IQueryable<TEntity> Query { get; }
        TEntity Get(params object[] key);
        void Add(TEntity entity);
        void AddRange(List<TEntity> entities);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        void Remove(params object[] key);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}