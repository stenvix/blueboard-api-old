using BlueBoard.Domain;
using System;
using System.Threading.Tasks;

namespace BlueBoard.Persistence.Repositories
{
    public interface IUserRepository : IRepository<User, Guid>
    {
        Task<User> GetByEmailAsync(string email);
    }
}
