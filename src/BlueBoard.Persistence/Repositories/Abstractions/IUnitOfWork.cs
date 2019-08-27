using System;
using System.Threading.Tasks;

namespace BlueBoard.Persistence.Repositories
{
    public interface IUnitOfWork
    {
        TRepository GetRepository<TRepository>() where TRepository : IRepository;
        Task<int> SaveChangesAsync();
        IDisposable BeginTransaction();
        void CommitTransaction(IDisposable transaction);
        void RollbackTransaction(IDisposable transaction);
    }
}
