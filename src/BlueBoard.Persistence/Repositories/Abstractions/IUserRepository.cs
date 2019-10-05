using BlueBoard.Common.Enums;
using BlueBoard.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlueBoard.Persistence.Repositories
{
    public interface IUserRepository : IRepository<User, Guid>
    {
        Task<User> GetByEmailAsync(string email);
        Task<User> GetByEmailOrUsernameAsync(string login);
        Task<User> GetWithStatusAsync(Guid userId, UserStatus status);
        Task<User> GetActiveAsync(Guid userId);
        Task<bool> ExistsByEmailAsync(string email);
        Task<IList<User>> SearchAsync(string query, Guid currentUserId);
    }
}
