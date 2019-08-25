using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;

namespace BlueBoard.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Fields

        private readonly BlueBoardContext _context;

        #endregion

        public UnitOfWork(BlueBoardContext context)
        {
            _context = context;
        }

        public TRepository GetRepository<TRepository>()
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public IDisposable BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }

        public void CommitTransaction(IDisposable transaction)
        {
            if (!(transaction is IDbContextTransaction dbTransaction))
            {
                throw new ArgumentNullException(nameof(transaction), "Transaction can't be null");
            }
            dbTransaction.Commit();
        }

        public void RollbackTransaction(IDisposable transaction)
        {
            if (!(transaction is IDbContextTransaction dbTransaction))
            {
                throw new ArgumentNullException(nameof(transaction), "Transaction can't be null");
            }
            dbTransaction.Rollback();
        }
    }
}
