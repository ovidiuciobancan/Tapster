using System;
using System.Threading.Tasks;

namespace Utils.DataAccess.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();
        Task<int> SaveChangesAsync();
        int InTransaction(Action predicate);
        Task<int> InTransactionAsync(Action predicate);
    }
}