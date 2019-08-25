using System.Threading.Tasks;
using BlueBoard.Domain;

namespace BlueBoard.Persistence.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByEmailAsync(string email);
        Task CreateAsync(User user);
    }
}
