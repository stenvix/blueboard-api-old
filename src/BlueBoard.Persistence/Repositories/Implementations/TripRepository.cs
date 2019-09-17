using BlueBoard.Common.Enums;
using BlueBoard.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            var entities = await GetForUserQuery(userId).ToListAsync();
            return entities;
        }

        public Task<bool> HasAccessAsync(Guid tripId, Guid userId)
        {
            return Set.Where(i => i.Id == tripId &&
                                  _activeStatuses.Contains(i.Status) &&
                                  (i.CreatedById == userId || i.Participants.Any(p => p.UserId == userId)))
                .AnyAsync();
        }

        public async Task<IList<Trip>> SearchForUserAsync(Guid userId, string query, DateTime? fromDate, DateTime? toDate)
        {
            var entities = GetForUserQuery(userId);
            if (!string.IsNullOrEmpty(query))
            {
                entities = entities.Where(i => i.Name.Contains(query) ||
                                               i.Description.Contains(query) ||
                                               i.Countries.Any(c => c.Country.Name.Contains(query)));
            }

            if (fromDate.HasValue)
            {
                entities = entities.Where(i => i.StartDate >= fromDate.Value);
            }

            if (toDate.HasValue)
            {
                entities = entities.Where(i => i.StartDate <= toDate.Value);
            }

            var result = await entities.ToListAsync();
            return result;
        }


        private IQueryable<Trip> GetForUserQuery(Guid userId)
        {
            return Set.Include(i => i.Countries)
                .ThenInclude(i => i.Country)
                .Where(i => _activeStatuses.Contains(i.Status) &&
                            (i.CreatedById == userId || i.Participants.Any(p => p.UserId == userId)));
        }
    }
}
