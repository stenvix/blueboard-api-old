using BlueBoard.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlueBoard.Persistence.Repositories
{
    public interface ITripRepository : IRepository<Trip, Guid>
    {
        Task<IList<Trip>> GetForUserAsync(Guid userId);
        Task<bool> HasAccessAsync(Guid tripId, Guid userId);
    }
}
