using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlueBoard.Persistence.Repositories
{
    public interface IRepository { }

    public interface IRepository<TEntity, TKey> : IRepository where TEntity : class
    {
        Task<bool> ExistsAsync(TKey id);
        Task<IList<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(TKey id);
        Task CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TKey id);
    }
}