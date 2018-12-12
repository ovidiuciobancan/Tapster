using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Utils.DataAccess.Interfaces;

namespace Utils.DataAccess
{
    public class EfCoreUnitOfWork : IUnitOfWork, IDisposable 
    {
        protected DbContext context;
        public EfCoreUnitOfWork(DbContext context)
        {
            this.context = context;
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (context != null)
                {
                    context.Dispose();
                    context = null;
                }
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public int InTransaction(Action predicate)
        {
            using (var tranzaction = context.Database.BeginTransaction())
            {
                try
                {
                    predicate();
                    var result = SaveChanges();
                    tranzaction.Commit();
                    return result;
                }
                catch (Exception ex)
                {
                    tranzaction.Rollback();
                    throw ex;
                }
            }
        }
        public async Task<int> InTransactionAsync(Action predicate)
        {
            using (var tranzaction = await context.Database.BeginTransactionAsync())
            {
                try
                {
                    predicate();
                    var result = SaveChangesAsync();
                    tranzaction.Commit();
                    return await result;
                }
                catch (Exception ex)
                {
                    tranzaction.Rollback();
                    throw ex;
                }
            }
        }

        public int SaveChanges()
        {
            return context.SaveChanges();
        }
        public async Task<int> SaveChangesAsync()
        {
            return await SaveChangesAsync();
        }
    }
}