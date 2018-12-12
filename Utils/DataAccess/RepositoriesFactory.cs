using Microsoft.EntityFrameworkCore;

namespace Utils.DataAccess
{
    public class RepositoriesFactory
    {
        private readonly DbContext context;

        public RepositoriesFactory(DbContext context)
        {
            this.context = context;
        }

        public EfCoreRepository<TEntity> Repository<TEntity>()
            where TEntity : class, new()
        {
            return new EfCoreRepository<TEntity>(context);
        }
    }
}
