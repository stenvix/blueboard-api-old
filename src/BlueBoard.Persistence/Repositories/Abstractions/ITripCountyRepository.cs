using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlueBoard.Persistence.Repositories
{
    public interface ITripCountyRepository : IRepository
    {
        Task CreateForTripAsync(Guid tripId, IList<Guid> countries);
        Task UpdateForTripAsync(Guid tripId, IList<Guid> countries);
    }
}
