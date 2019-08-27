using BlueBoard.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlueBoard.Common.Enums;

namespace BlueBoard.Persistence.Repositories
{
    public class TripRepository : BaseRepository<Trip, Guid>, ITripRepository
    {
        private static readonly TripStatus[] _activeStatuses = { TripStatus.Current, TripStatus.Future };
        public TripRepository(BlueBoardContext context) : base(context)
        {
        }

        public override Task<Trip> GetAsync(Guid id)
        {
            return Set.Include(i => i.Countries)
                .ThenInclude(i => i.Country)
                .FirstOrDefaultAsync(i => i.Id == id && _activeStatuses.Contains(i.Status));
        }

        public async Task<IList<Trip>> GetForUserAsync(Guid userId)
        {
            var entities = await Set.Include(i => i.Countries)
                .ThenInclude(i => i.Country)
                .Where(i => _activeStatuses.Contains(i.Status) &&
                            (i.CreatedById == userId || i.Participants.Any(p => p.UserId == userId)))
                .ToListAsync();
            return entities;
        }

        public Task<bool> HasAccessAsync(Guid tripId, Guid userId)
        {
            return Set.Where(i => i.Id == tripId &&
                                  _activeStatuses.Contains(i.Status) &&
                                  (i.CreatedById == userId || i.Participants.Any(p => p.UserId == userId)))
                .AnyAsync();
        }
    }
}
