﻿using BlueBoard.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueBoard.Persistence.Repositories
{
    public class ParticipantRepository : BaseRepository<Participant, Guid>, IParticipantRepository
    {
        public ParticipantRepository(BlueBoardContext context) : base(context)
        {
        }

        public async Task<IList<Participant>> GetForTripAsync(Guid tripId)
        {
            var entities = await Set.Include(i => i.User)
                .Where(i => i.TripId == tripId).ToListAsync();

            return entities;
        }

        public async Task<IList<Participant>> GetForSearchAsync(Guid tripId)
        {
            var entities = await Set.Where(i => i.TripId == tripId).ToListAsync();
            return entities;
        }

        public Task<Participant> GetForTripAsync(Guid tripId, string username)
        {
            return Set.Where(i => i.TripId == tripId && i.User.Username == username)
                .FirstOrDefaultAsync();
        }

        public Task<bool> ExistsAsync(Guid userId, Guid tripId)
        {
            return Set.Where(i => i.TripId == tripId && i.UserId == userId).AnyAsync();
        }
    }
}
