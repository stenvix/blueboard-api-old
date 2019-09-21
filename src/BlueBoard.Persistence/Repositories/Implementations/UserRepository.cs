using BlueBoard.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using BlueBoard.Common.Enums;

namespace BlueBoard.Persistence.Repositories
{
    public class UserRepository : BaseRepository<User, Guid>, IUserRepository
    {
        public UserRepository(BlueBoardContext context) : base(context)
        {
        }

        public Task<User> GetByEmailAsync(string email)
        {
            return Set.FirstOrDefaultAsync(i => i.Email == email);
        }

        public Task<User> GetWithStatusAsync(Guid userId, UserStatus status)
        {
            return Set.Where(i => i.Id == userId &&
                                  i.Status == status)
                .FirstOrDefaultAsync();
        }

        public Task<User> GetActiveAsync(Guid userId)
        {
            return Set.Where(i => i.Id == userId &&
                                  i.Status != UserStatus.Removed)
                .FirstOrDefaultAsync();
        }

        public Task<bool> ExistsByEmailAsync(string email)
        {
            return Set.Where(i => i.Email == email).AnyAsync();
        }
    }
}
