using BlueBoard.Common.Enums;
using BlueBoard.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public Task<User> GetByUsernameAsync(string username)
        {
            return Set.FirstOrDefaultAsync(i => i.Username == username);
        }

        public Task<User> GetByEmailOrUsernameAsync(string login)
        {
            return Set.FirstOrDefaultAsync(i => i.Email == login || i.Username == login);
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

        public async Task<IList<User>> SearchAsync(string query, Guid currentUserId)
        {
            var entities = await Set.Where(i => (i.FirstName.Contains(query) ||
                                          i.LastName.Contains(query) ||
                                          i.Email.Contains(query) ||
                                          i.Username.Contains(query)) &&
                                                i.Id != currentUserId)
                .Select(i => new User
                {
                    FirstName = i.FirstName,
                    LastName = i.LastName,
                    Username = i.Username,
                    Avatar = i.Avatar
                })
                .ToListAsync();

            return entities;
        }
    }
}
