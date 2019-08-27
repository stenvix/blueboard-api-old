using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BlueBoard.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Fields

        private readonly BlueBoardContext _context;
        private readonly ConcurrentDictionary<string, object> _repositories = new ConcurrentDictionary<string, object>();

        #endregion

        public UnitOfWork(BlueBoardContext context)
        {
            _context = context;
        }

        public TRepository GetRepository<TRepository>() where TRepository : IRepository
        {
            return (TRepository)_repositories.GetOrAdd(typeof(TRepository).Name, CreateSpecificRepository<TRepository>());
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

        private object CreateSpecificRepository<TRepository>() where TRepository : IRepository
        {
            var implementationTypes = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.GetInterfaces().Contains(typeof(TRepository))).ToList();
            if (implementationTypes.Count == 0)
            {
                throw new InvalidOperationException("There is no implementation of this repository interface");
            }

            if (implementationTypes.Count > 1)
            {
                throw new InvalidOperationException("There are multiple implementation of this repository interface");
            }

            var repositoryClassType = implementationTypes.First();
            var repositoryInstance = Activator.CreateInstance(repositoryClassType, _context);

            return repositoryInstance;
        }
    }
}
