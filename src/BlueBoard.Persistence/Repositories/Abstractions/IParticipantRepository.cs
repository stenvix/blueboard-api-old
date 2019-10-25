using BlueBoard.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlueBoard.Persistence.Repositories
{
    public interface IParticipantRepository : IRepository<Participant, Guid>
    {
        Task<IList<Participant>> GetForTripAsync(Guid tripId);
        Task<IList<Participant>> GetForSearchAsync(Guid tripId);
        Task<Participant> GetForTripAsync(Guid tripId, string username);
        Task<bool> ExistsAsync(Guid userId, Guid tripId);
    }
}
