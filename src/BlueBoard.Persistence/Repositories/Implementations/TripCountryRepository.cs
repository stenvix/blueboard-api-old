using BlueBoard.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueBoard.Persistence.Repositories
{
    public class TripCountryRepository : BaseRepository, ITripCountyRepository
    {
        public TripCountryRepository(BlueBoardContext context) : base(context)
        {
        }

        public Task CreateForTripAsync(Guid tripId, IList<Guid> countries)
        {
            var entities = countries.Distinct().Select(i => new TripCountry { TripId = tripId, CountryId = i });
            return Context.TripCountries.AddRangeAsync(entities);
        }

        public async Task UpdateForTripAsync(Guid tripId, IList<Guid> countries)
        {
            var entities = Context.TripCountries.Where(i => i.TripId == tripId).ToList();
            var entitiesIds = entities.Select(i => i.CountryId).ToList();
            var create = countries.Except(entitiesIds).ToList();
            var remove = entitiesIds.Except(countries).ToList();
            if (!create.Any() || !remove.Any()) return;

            await Context.TripCountries.AddRangeAsync(create.Select(i => new TripCountry { TripId = tripId, CountryId = i, }));
            Context.TripCountries.RemoveRange(entities.Where(i => remove.Contains(i.CountryId)));
        }
    }
}
