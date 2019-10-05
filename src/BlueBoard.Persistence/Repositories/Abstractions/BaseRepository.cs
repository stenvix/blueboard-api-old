using BlueBoard.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlueBoard.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly BlueBoardContext Context;

        protected BaseRepository(BlueBoardContext context)
        {
            Context = context;
        }
    }

    public abstract class BaseRepository<TEntity, TKey> : BaseRepository, IRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        protected DbSet<TEntity> Set;

        protected BaseRepository(BlueBoardContext context) : base(context)
        {
            Set = context.Set<TEntity>();
        }

        public Task<bool> ExistsAsync(TKey id)
        {
            return Set.AnyAsync(i => i.Id.Equals(id));
        }

        public virtual async Task<IList<TEntity>> GetAllAsync()
        {
            var entities = await Set.ToListAsync();
            return entities;
        }

        public virtual Task<TEntity> GetAsync(TKey id)
        {
            return Set.FindAsync(id).AsTask();
        }

        public virtual Task CreateAsync(TEntity entity)
        {
            Set.Add(entity);
            return Task.CompletedTask;
        }

        public virtual Task UpdateAsync(TEntity entity)
        {
            Set.Update(entity);
            return Task.CompletedTask;
        }

        public virtual async Task DeleteAsync(TKey id)
        {
            var entity = await Set.FindAsync(id);
            if (entity == null) throw new ArgumentNullException(nameof(entity), $"Entity {id} not found");
            Set.Remove(entity);
        }
    }
}
