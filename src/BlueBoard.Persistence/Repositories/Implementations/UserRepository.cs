using BlueBoard.Domain;
using Microsoft.EntityFrameworkCore;
using System;
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
    }
}
