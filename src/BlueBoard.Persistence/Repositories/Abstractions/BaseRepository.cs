using Microsoft.EntityFrameworkCore;

namespace BlueBoard.Persistence.Repositories
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly BlueBoardContext Context;
        protected DbSet<TEntity> Set;

        protected BaseRepository(BlueBoardContext context)
        {
            Context = context;
            Set = context.Set<TEntity>();
        }
    }
}
