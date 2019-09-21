using BlueBoard.Domain;
using System;
using System.Threading.Tasks;
using BlueBoard.Common.Enums;

namespace BlueBoard.Persistence.Repositories
{
    public interface IUserRepository : IRepository<User, Guid>
    {
        Task<User> GetByEmailAsync(string email);
        Task<User> GetWithStatusAsync(Guid userId, UserStatus status);
        Task<User> GetActiveAsync(Guid userId);
        Task<bool> ExistsByEmailAsync(string email);
    }
}
